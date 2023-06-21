using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
   
   

    public float velocidad;
    public int danio;
    public GameObject explosion;
    public Transform  fireBall;
  
    void Update()
    {

        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
      
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
