using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeWorm : MonoBehaviour
{
    protected Animator animator;

    public Rigidbody2D theRB;

    public GameObject[] jugadores;

    protected bool mirandoDerecha = true;

    protected  bool canHit;

    protected SpriteRenderer theSR;

    public float mitadVida;

    public GameObject particula;

    public GameObject diamante;

    public  float max = 1f;

    public float timer = 30f;

    public bool changeVisible = false;

    public GameObject corazon;

    // VIDA

    

    private void Start()
    {
        mitadVida = GetComponent<Enemigo>().vida / 2f;
        theSR = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        theRB = GetComponent<Rigidbody2D>();
        jugadores = GameObject.FindGameObjectsWithTag("Player");
    }


    public void Muerte()
    {
        
        Debug.Log("Muerto");
        StartCoroutine(wait5Seconds());
        
       
    }

    public void setChangeVisible()
    {
        changeVisible = !changeVisible;
    }

    public void ChangeVisible()
    {
        if(timer > 0 && changeVisible && max >= 0)
        {
            theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, max);
            max -= Time.deltaTime * 0.2f;
            timer -= Time.deltaTime;
        }

    }

    public void activarParticula()
    {
        Instantiate(particula, new Vector3(transform.position.x, transform.position.y, transform.position.z),  transform.rotation);
    }

    public void MirarJugador()
    {
       
        int indexMenor = 0;

        if( Vector3.Distance(transform.position, jugadores[0].transform.position) <= Vector3.Distance(transform.position, jugadores[1].transform.position))
        {
            indexMenor = 0;
        }
        else 
        {
            indexMenor = 1;
        }

        if((jugadores[indexMenor].transform.position.x > transform.position.x && !mirandoDerecha) || (jugadores[indexMenor].transform.position.x < transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    public void doCoroutine()
    {
        StartCoroutine(wait2Second(animator));
    }

    private IEnumerator wait5Seconds()
    {
        
        yield return new WaitForSeconds(7f);
        Instantiate(diamante,  new Vector3(transform.position.x, transform.position.y - 0.23f, transform.position.z),  transform.rotation);
        Instantiate(corazon, new Vector3(transform.position.x, transform.position.y + 0.23f, transform.position.z ), Quaternion.identity);
        Destroy(gameObject);
    }
    
   

    private IEnumerator wait2Second(Animator animator)
    {
        yield return new WaitForSeconds(3f);
        animator.SetInteger("NumeroAleatorio", Random.Range(0,2));
    }

}
