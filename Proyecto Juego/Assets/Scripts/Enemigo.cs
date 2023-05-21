using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
  
    public float vida;

 //   [SerializeField] private GameObject efectoMuerte;



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
        Destroy(gameObject);
    }
    
}
