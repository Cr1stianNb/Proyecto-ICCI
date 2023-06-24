using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazon : MonoBehaviour
{
    

    public Rigidbody2D theRB;
    
    public int vidaRecuperada = 1;
   


    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        theRB.Sleep();
        Debug.Log(theRB.IsSleeping());
    }

    public void wakeRigidBody2D()
    {
        theRB.WakeUp();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Entro");
            other.GetComponent<PlayerHealthController>().RecuperarSalud(vidaRecuperada);
            Destroy(gameObject);
        }
    }

    


}
