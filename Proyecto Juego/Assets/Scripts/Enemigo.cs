using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
  
    public float vida;
    public float cantPuntos;
    private Puntaje puntaje;
 //   [SerializeField] private GameObject efectoMuerte;


    private void Start()
    {
        puntaje = GameObject.Find("Puntaje").GetComponent<Puntaje>();
    }

    public void TomarDanio(float danio)
    {
        vida -= danio;
        if(vida <=0)
        {
            Muerte();
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
    
}
