using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
   
   

    public float velocidad = 1f;
    public float velocidadMax = 7;
    public float velocidadImp =  0.1f;
    public int danio;
    public GameObject explosion;
    public Transform  fireBall;
  
    void Update()
    {
        velocidad += velocidadImp;
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);

        if(velocidad >= velocidadMax)
        {
            velocidad = velocidadMax;
        }
      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
           other.GetComponent<PlayerHealthController>().DealDamage(danio);
           Destroy(gameObject);
           Instantiate(explosion, fireBall.position, Quaternion.identity);
        }
        else 
        {

        }

    }



}
