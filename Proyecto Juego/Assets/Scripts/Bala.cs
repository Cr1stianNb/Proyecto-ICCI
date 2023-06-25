using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bala : MonoBehaviour
{
   

    public float velocidad;
    public float danio;


    private Transform owner;
   

    private void Start()
    {
        owner = GetComponentInParent<Transform>(); 
    }

    void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemigo"))
        {
           other.GetComponent<Enemigo>().TomarDanio(danio);
           Destroy(gameObject);
        }
        else if(other.CompareTag("Player") && other.gameObject.transform != owner)
        {
            other.GetComponent<PlayerHealthController>().DealDamage((int)danio);
        }

    }


   

}
