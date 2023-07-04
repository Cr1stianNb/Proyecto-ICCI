using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoBolaSeguir : MonoBehaviour
{
    public float velocidad = 1f;
    public float velocidadMax = 7;
    public float velocidadImp =  0.1f;
    public int danio;
    public float suavidad = 0.1f;
    public GameObject explosion;
    public Transform  fireBall;
    public Transform player;

    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if(players.Length > 1)
        {
            int numeroAleatorio = Random.Range(0,2);

            player = players[numeroAleatorio].transform;
        }
        else 
        {
            player = players[0].transform;

        }
    }
  
    void Update()
    {
        velocidad += velocidadImp;
        
        transform.position = Vector2.Lerp(transform.position, player.position, suavidad * Time.deltaTime * velocidad);

        if(velocidad >= velocidadMax)
        {
            velocidad = velocidadMax;
        }


       // transform.position = new Vector3(jugador.position.x, Mathf.Clamp(jugador.position.y, alturaMin, alturaMax), transform.position.z);
      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
           other.GetComponent<PlayerHealthController>().DealDamage(danio);
           Destroy(gameObject);
           Instantiate(explosion, fireBall.position, Quaternion.identity);
        }
        else 
        {

        }

    }
}
