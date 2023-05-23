using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
   

    public float velocidad;
    public float danio;
  
    

        

    

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

    }


   

}
