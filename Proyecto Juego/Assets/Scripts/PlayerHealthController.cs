using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealthController : MonoBehaviour
{

    public bool estaMuerto = false;

    public static PlayerHealthController instance;

    public int currentHealth, maxHealth;

    public float invincibleLength;

    private float invincibleCounter;

    private Transform checkpoint;

    public Transform player;

    public Animator animator;

    public Rigidbody2D rb2D;

    public event EventHandler MuerteJugador;

    //private SpriteRenderer theSR;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
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

    public void DealDamage()
    {   
        if(invincibleCounter <=0)
        {
            currentHealth--;
           // PlayerControler.instance.anim.SetTrigger("Hurt");


             if(currentHealth<=0 && !estaMuerto)
            {
        
                rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
                //Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("Enemigo"),true);
                estaMuerto = true;
                
                animator.SetTrigger("Muerte");
               



            }
            else
            {
                //theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 0.5f);
                //invincibleCounter = invincibleLength;

                //PlayerController.instance.knockBack();
            }

        // UIControler.instance.UpdateHealthDisplay();
        }

    }

    public void MuerteJugadorEvento()
    {
        MuerteJugador?.Invoke(this, EventArgs.Empty);
    }
}

