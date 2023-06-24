using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeWorm : MonoBehaviour
{
    private Animator animator;

    public Rigidbody2D theRB;

    public Transform jugador;

    private bool mirandoDerecha = true;

    private static bool canHit;

    public float mitadVida;

    // VIDA

    

    private void Start()
    {
        mitadVida = GetComponent<Enemigo>().vida / 2f;
        animator = GetComponent<Animator>();
        theRB = GetComponent<Rigidbody2D>();
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    private void Muerte()
    {
        Destroy(gameObject);
    }

    public void MirarJugador()
    {
        if((jugador.position.x > transform.position.x && !mirandoDerecha) || (jugador.position.x < transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    public void doCoroutine()
    {
        StartCoroutine(wait2Second(animator));
    }

    private IEnumerator wait2Second(Animator animator)
    {
        yield return new WaitForSeconds(3f);
        animator.SetInteger("NumeroAleatorio", Random.Range(0,2));
    }

}
