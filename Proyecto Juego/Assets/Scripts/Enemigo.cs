using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
  
    public float vida;
    public float cantPuntos;
   // private Puntaje puntaje;
    public float empujeX;
    private Rigidbody2D theRB;
    private Animator animator;
    public KnockBack knockBack;

    public bool canHit = true;

    

 //   [SerializeField] private GameObject efectoMuerte;


    private void Start()
    {
        //puntaje = GameObject.Find("Puntaje").GetComponent<Puntaje>();
        theRB = GetComponent<Rigidbody2D>();
        knockBack = GetComponent<KnockBack>();
        animator = GetComponent<Animator>();
    }

    public void TomarDanio(float danio)
    {
        if(canHit)
        {
            vida -= danio;
        }
        if(vida <=0 && canHit)
        {
            animator.SetTrigger("Muerte");
        }
        else if(canHit)
        {
            animator.SetTrigger("Golpe");
        }
    }

    public void TomarDanio(float danio, Transform player)
    {
        if(canHit)
        {
            vida -= danio;
        }
        if(vida <=0 && canHit)
        {
           animator.SetTrigger("Muerte");
        }
        else if(canHit)
        {
            animator.SetTrigger("Golpe");
            knockBack.knockBack(player);
        }
    }

    private void Muerte()
    {
      //  Instantiate(efectoMuerte, transform.position, Quaternion.identity);
       // puntaje.SumarPuntos(cantPuntos);
        Destroy(gameObject);
    }


    /*
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            
            collider.GetComponent<PlayerHealthController>().DealDamage(5, collider.GetContact(0).normal);            
             
        }
    }
    */

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealthController>().DealDamage(5, other.GetContact(0).normal);
        }
    }

    public void DoInmortal()
    {
        StartCoroutine(Inmortal());
    }

    private IEnumerator Inmortal()
    {
        canHit = false;
        yield return new WaitForSeconds(3f);
        canHit = true;

    }


   
    
}
