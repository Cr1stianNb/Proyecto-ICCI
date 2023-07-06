using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeIng : MonoBehaviour
{

    public float speed = 2f; 
    public float fireRate = 2f; 
    public GameObject projectilePrefab; 
    public float timeToChangeDirection = 10f; 

    public float nextFireTime; 
    public  float timeElapsed;
    private bool movingUp = true; 

    private void Start()
    {
        nextFireTime = Time.time + fireRate;
    }

    private void Update()
    {
       
        float movement = movingUp ? 1f : -1f;
        transform.Translate(Vector2.up * speed * movement * Time.deltaTime);

        
        timeElapsed += Time.deltaTime;

       
        if (timeElapsed >= timeToChangeDirection)
        {
            movingUp = !movingUp;
            timeElapsed = 0f;
        }

       
        if (Time.time >= nextFireTime)
        {
            FireProjectile();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void FireProjectile()
    {
       
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(-8f, 0f); // Establecer la velocidad hacia la izquierda
        }
        else
        {
            Debug.LogWarning("El prefab del proyectil no tiene un componente Rigidbody2D.");
        }
    }

}


   

