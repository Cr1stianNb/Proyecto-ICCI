using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public float chargeSpeed = 5f; // Velocidad de carga
    public float returnSpeed = 2f; // Velocidad de retorno
    public float chargeDuration = 2f; // Duraci�n de la carga en segundos
    public float returnDelay = 1f; // Retraso antes de volver a la posici�n original en segundos
    public float projectileSpeed = 10f; // Velocidad del proyectil
    public float fireRate = 2f; // Tasa de disparo en segundos
    public GameObject projectilePrefab; // Prefab del proyectil

    private bool isCharging = false; // Indicador de carga en progreso
    private Vector3 startPosition; // Posici�n original del enemigo
    private float chargeTimer = 0f; // Temporizador de carga
    private float returnTimer = 0f; // Temporizador de retorno
    private float nextFireTime; // Tiempo para el pr�ximo disparo

    private void Start()
    {
        startPosition = transform.position; // Guardar la posici�n original del enemigo
        nextFireTime = Time.time + fireRate; // Inicializar el tiempo para el pr�ximo disparo
    }

    private void Update()
    {
        if (isCharging)
        {
            Charge();
        }
        else
        {
            ReturnToStartPosition();
        }

        // Disparar si ha pasado suficiente tiempo
        if (Time.time >= nextFireTime)
        {
            FireProjectile();
            nextFireTime = Time.time + fireRate; // Actualizar el tiempo para el pr�ximo disparo
        }
    }

    private void Charge()
    {
        chargeTimer += Time.deltaTime;

        if (chargeTimer <= chargeDuration)
        {
            // Mover al enemigo hacia adelante en su orientaci�n actual
            transform.Translate(Vector2.left * chargeSpeed * Time.deltaTime);
        }
        else
        {
            // Cambiar la orientaci�n y comenzar el retorno
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            isCharging = false;
            returnTimer = 0f;
        }
    }

    private void ReturnToStartPosition()
    {
        returnTimer += Time.deltaTime;

        if (returnTimer >= returnDelay)
        {
            // Mover al enemigo hacia la posici�n original
            float step = returnSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, startPosition, step);

            // Comprobar si ha vuelto a la posici�n original
            if (transform.position == startPosition)
            {
                // Restaurar la orientaci�n original
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

                // Reiniciar los temporizadores
                chargeTimer = 0f;
                returnTimer = 0f;

                // Decidir si cargar o disparar aleatoriamente
                float randomValue = Random.value;
                if (randomValue < 0.5f)
                {
                    isCharging = true;
                }
                else
                {
                    FireProjectile();
                }
            }
        }

        
    }
       private void FireProjectile()
        {
            // Instanciar el proyectil en la posici�n y rotaci�n del enemigo
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        } 
}
