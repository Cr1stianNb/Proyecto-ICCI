using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DisparoPlayer : MonoBehaviour
{



    public Transform controladorDisparo;
    public Transform controladorDisparoHalf;
   // public Transform controladorPunter;
    private float angulo ;
    public GameObject bala;
    public float coolDown;
    public float timeBetweenShot = 0.7f;

    public PlayerHealthController playerHealth;


    void Start()
    {
        playerHealth = GetComponent<PlayerHealthController>();
    }


    private void Update()
    {
        
       if(!playerHealth.estaMuerto && coolDown < 0f)
       {
            if(Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.S))
            {
                DispararMedio();
                coolDown = timeBetweenShot;
            }
            else if(Input.GetButtonDown("Fire1"))
            {
                Disparar();
                coolDown = timeBetweenShot;
            }

            
       }
       else 
       {
        coolDown -= Time.deltaTime;
       }
        
        /*
        if(Input.GetButtonDown("Fire1"))
        {
            DispararMouse();
        }
        */



    }

    private void Disparar()
    {
        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
    }

    private void DispararMedio()
    {
        Instantiate(bala, controladorDisparoHalf.position, controladorDisparoHalf.rotation);
    }

    /*
    private void DispararMouse()
    {
        if(Mathf.Abs(controladorDisparoHalf.position.x - controladorPunter.position.x) != 0)
        {
            angulo = Mathf.Rad2Deg * (Mathf.Atan((controladorDisparoHalf.position.y - controladorPunter.position.y)/(controladorDisparoHalf.position.x - controladorPunter.position.x)));
            Debug.Log(angulo);
            
            if((controladorDisparoHalf.position.y > controladorPunter.position.y) && controladorDisparoHalf.position.x > controladorPunter.position.x )
            {
                angulo += 180;
            }
            if(controladorPunter.position.y > controladorDisparoHalf.position.y && controladorDisparoHalf.position.x > controladorPunter.position.x )
            {
                angulo += 180;
            }
            
            Instantiate(bala, controladorDisparoHalf.position, Quaternion.Euler(Vector3.forward * angulo));
        }
           
    }
    */




  
}
