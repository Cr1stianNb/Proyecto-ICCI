using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPlayer : MonoBehaviour
{



    public Transform controladorDisparo;
    public GameObject bala;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
           Disparar();
        }



    }

    private void Disparar()
    {
        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
    }




  
}
