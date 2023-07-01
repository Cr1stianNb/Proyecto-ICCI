using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DisparoPlayer : MonoBehaviour
{



    public Transform controladorDisparo;
    public Transform controladorDisparoHalf;
   // public Transform controladorPunter;
    private float angulo ;
    public GameObject bala;
    public float coolDown;
    public float timeBetweenShot = 0.7f;

    public string proyectoFire;
    public PlayerHealthController playerHealth;
    public KeyCode keycode;

    
    public static event EventHandler OnBeginShot;
    public static bool canShot = true;


    void Start()
    {
        playerHealth = GetComponent<PlayerHealthController>();
    }


    private void Update()
    {
        if(canShot)
        {
            if(!playerHealth.estaMuerto && coolDown < 0f)
            {
                    if(Input.GetButtonDown(proyectoFire) && Input.GetKey(keycode) && !SistemaPausa.isPaused)
                    {
                        
                        DispararMedio();
                        DisparoPlayer.OnBeginShot?.Invoke(this, EventArgs.Empty);
                        coolDown = timeBetweenShot;
                    }
                    else if(Input.GetButtonDown(proyectoFire) && !SistemaPausa.isPaused)
                    {
                        
                        Disparar();
                        DisparoPlayer.OnBeginShot?.Invoke(this, EventArgs.Empty);
                        coolDown = timeBetweenShot;
                    }

                    
            }
            else 
            {
                coolDown -= Time.deltaTime;
            }
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
        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation, transform);
        
    }

    private void DispararMedio()
    {
        Instantiate(bala, controladorDisparoHalf.position, controladorDisparoHalf.rotation, transform);
       
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
