using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
  
    public float vida;
    public float cantPuntos;
    private Puntaje puntaje;
    public float empujeX;
    private Rigidbody2D theRB;
    
    public KnockBack knockBack;
 //   [SerializeField] private GameObject efectoMuerte;


    private void Start()
    {
        puntaje = GameObject.Find("Puntaje").GetComponent<Puntaje>();
        theRB = GetComponent<Rigidbody2D>();
        knockBack = GetComponent<KnockBack>();
    }

    public void TomarDanio(float danio)
    {
        vida -= danio;
        if(vida <=0)
        {
            Muerte();
        }
    }

    public void TomarDanio(float danio, Transform player)
    {
        vida -= danio;
        if(vida <=0)
        {
            Muerte();
        }
        else 
        {
           knockBack.knockBack(player);
        }
    }

    private void Muerte()
    {
      //  Instantiate(efectoMuerte, transform.position, Quaternion.identity);
        puntaje.SumarPuntos(cantPuntos);
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


    public void Rebote(Vector3 puntoGolpe)
    {
        Vector3 puntoGolpe1 = new Vector3();
        if(puntoGolpe.x >= 0)
        {
            puntoGolpe1 = Vector3.right;
        }
        else 
        {
            puntoGolpe1 = Vector3.left;
        }
        theRB.velocity = new Vector2(empujeX * puntoGolpe1.x , 0f); 
    }
    
}
