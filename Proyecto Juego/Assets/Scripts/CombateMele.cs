using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateMele : MonoBehaviour
{


    public Transform controladorGolpe;

    public float radioGolpe;
    public float danioGolpe;


    public float tiempoEntreAtaque;
    public float tiempoSiguienteAtaque;
    private Animator animator;
    public PlayerHealthController playerHealth;

    public string proyectoFire2;


    public static bool canMeleCombat = false;



    
    private void Start()
    {
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealthController>();
       
    }
    // Update is called once per frame
    void Update()
    {
        if(canMeleCombat)
        {

        
            if(tiempoSiguienteAtaque > 0)
            {
                tiempoSiguienteAtaque -= Time.deltaTime;
            }
            if(Input.GetButtonDown(proyectoFire2) && tiempoSiguienteAtaque <=0 && !playerHealth.estaMuerto)
            {
                
                animator.SetTrigger("Golpe");
                tiempoSiguienteAtaque = tiempoEntreAtaque;
            }
        }
    }

    private void Golpe()
    {

        //animator.SetTrigger("Golpe");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);
        
        foreach(Collider2D colisionador in objetos)
        {
            if(colisionador.CompareTag("Enemigo"))
            {
                colisionador.transform.GetComponent<Enemigo>().TomarDanio(danioGolpe, controladorGolpe);
            }
            else if(colisionador.CompareTag("Player") && colisionador.gameObject != gameObject)
            {
                colisionador.transform.GetComponent<PlayerHealthController>().DealDamage((int)danioGolpe, controladorGolpe);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }

   
}
