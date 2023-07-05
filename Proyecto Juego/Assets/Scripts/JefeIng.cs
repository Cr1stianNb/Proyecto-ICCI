using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeIng : MonoBehaviour
{

    public float speed = 2f; // Velocidad de movimiento vertical
    public float fireRate = 2f; // Tasa de disparo en segundos
    public GameObject projectilePrefab; // Prefab del proyectil
    public float timeToChangeDirection = 3f; // Tiempo en segundos antes de cambiar la dirección del movimiento

    private float nextFireTime; // Tiempo para el próximo disparo
    private float timeElapsed; // Tiempo transcurrido desde el cambio de dirección
    private bool movingUp = true; // Indicador de dirección de movimiento

    private void Start()
    {
        nextFireTime = Time.time + fireRate; // Inicializar el tiempo para el próximo disparo
    }

    private void Update()
    {
        // Mover el enemigo verticalmente
        float movement = movingUp ? 1f : -1f;
        transform.Translate(Vector2.up * speed * movement * Time.deltaTime);

        // Incrementar el tiempo transcurrido
        timeElapsed += Time.deltaTime;

        // Cambiar la dirección de movimiento si ha pasado el tiempo especificado
        if (timeElapsed >= timeToChangeDirection)
        {
            movingUp = !movingUp;
            timeElapsed = 0f;
        }

        // Disparar si ha pasado suficiente tiempo
        if (Time.time >= nextFireTime)
        {
            FireProjectile();
            nextFireTime = Time.time + fireRate; // Actualizar el tiempo para el próximo disparo
        }
    }

    private void FireProjectile()
    {
        // Instanciar el proyectil en la posición y rotación del enemigo
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        // Configurar la velocidad del proyectil
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(-1f, 0f); // Establecer la velocidad hacia la izquierda
        }
        else
        {
            Debug.LogWarning("El prefab del proyectil no tiene un componente Rigidbody2D.");
        }
    }

}


   

