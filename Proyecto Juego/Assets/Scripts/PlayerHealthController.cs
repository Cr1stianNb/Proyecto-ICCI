using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealthController : MonoBehaviour
{

    private PlayerController playerController;

    public float tiempoPerdidaJugador;

    public bool estaMuerto = false;

    public static PlayerHealthController instance;

    public int currentHealth, maxHealth;

    public float invincibleLength;

    private float invincibleCounter;

    private Transform checkpoint;

    public Transform player;

    public Animator animator;

    public Rigidbody2D rb2D;

    public static event EventHandler MuerteJugador;

    public KnockBack knockBack;

    public MenuReiniciar menuReiniciar;

    //private SpriteRenderer theSR;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        player = GetComponent<Transform>();
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        knockBack = GetComponent<KnockBack>();
       // theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    /*
    void Update()
    {
        if(invincibleCounter > 0) 
        {
            invincibleCounter -= Time.deltaTime;
            if(invincibleCounter <= 0)
            {
                //theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
    }*/

    public void DealDamage(int daño)
    {   
    
        currentHealth -= daño;
        // PlayerControler.instance.anim.SetTrigger("Hurt");

        if(currentHealth<=0 && !estaMuerto)
        {
        
            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
            //Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("Enemigo"),true);
    
                
            animator.SetTrigger("Muerte");
            animator.SetBool("IsDead", true);



        }
        else
        {
            animator.SetTrigger("Daño");

            //playerController.Rebote(posicion);
            


                //PlayerController.instance.knockBack();
            }

        //UIVidaCanvas.instance.UpdateHealthDisplay();

            

        }

    // UIControler.instance.UpdateHealthDisplay();
    


    public void DealDamage(int daño, Transform posicion)
    {   
    
        currentHealth -= daño;

        if(currentHealth<=0 && !estaMuerto)
        {
        
            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
            //Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("Enemigo"),true);

            animator.SetBool("IsDead", true);
            animator.SetTrigger("Muerte");
               



        }
        else if(!estaMuerto)
        {
            animator.SetTrigger("Daño");
            knockBack.knockBack(posicion);
            //StartCoroutine(PerderControl());
            StartCoroutine(DesactivarColision());  
            //playerController.Rebote(posicion);
            

            
        }

    // UIControler.instance.UpdateHealthDisplay();
    }

    private IEnumerator PerderControl()
    {
        playerController.canMove = false;
        yield return new  WaitForSeconds(tiempoPerdidaJugador);
        playerController.canMove = true;
    }


    private IEnumerator DesactivarColision()
    {
        Physics2D.IgnoreLayerCollision(9,12,true);
        yield return new WaitForSeconds(tiempoPerdidaJugador+0.5f);
        Physics2D.IgnoreLayerCollision(9,12,false);
    }


    public  void MuerteJugadorEvento()
    {
        MuerteJugador?.Invoke(null, EventArgs.Empty);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "platform")
        {
            transform.parent = other.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "platform")
        {
            transform.parent = null;
        }
    }

    public void RecuperarSalud(int salud)
    {
        currentHealth += salud;
    }

    public void RecuperarTodaLaSalud()
    {
        currentHealth = maxHealth;
        animator.SetBool("IsDead", false);
        rb2D.constraints = RigidbodyConstraints2D.None;
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    


}

