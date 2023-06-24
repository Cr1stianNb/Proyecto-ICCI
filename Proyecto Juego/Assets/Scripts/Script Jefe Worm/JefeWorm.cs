using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeWorm : MonoBehaviour
{
    private Animator animator;

    public Rigidbody2D theRB;

    public Transform jugador;

    private bool mirandoDerecha = true;

    private  bool canHit;

    private SpriteRenderer theSR;

    public float mitadVida;

    public GameObject particula;

    public GameObject diamante;

    public  float max = 1f;

    public float timer = 30f;

    public bool changeVisible = false;

    // VIDA

    

    private void Start()
    {
        mitadVida = GetComponent<Enemigo>().vida / 2f;
        theSR = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        theRB = GetComponent<Rigidbody2D>();
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    public void Muerte()
    {
        
        Debug.Log("Muerto");
        StartCoroutine(wait5Seconds());
        
       
    }

    public void setChangeVisible()
    {
        changeVisible = !changeVisible;
    }

    public void ChangeVisible()
    {
        if(timer > 0 && changeVisible && max >= 0)
        {
            theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, max);
            max -= Time.deltaTime * 0.2f;
            timer -= Time.deltaTime;
        }

    }

    public void activarParticula()
    {
        Instantiate(particula, new Vector3(transform.position.x, transform.position.y, transform.position.z),  transform.rotation);
    }

    public void MirarJugador()
    {
        if((jugador.position.x > transform.position.x && !mirandoDerecha) || (jugador.position.x < transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    public void doCoroutine()
    {
        StartCoroutine(wait2Second(animator));
    }

    private IEnumerator wait5Seconds()
    {
        
        yield return new WaitForSeconds(7f);
        Instantiate(diamante,  new Vector3(transform.position.x, transform.position.y - 0.23f, transform.position.z),  transform.rotation);
        Destroy(gameObject);
    }
    
   

    private IEnumerator wait2Second(Animator animator)
    {
        yield return new WaitForSeconds(3f);
        animator.SetInteger("NumeroAleatorio", Random.Range(0,2));
    }

}
