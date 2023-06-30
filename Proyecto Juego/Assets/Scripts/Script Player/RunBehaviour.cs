using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunBehaviour : StateMachineBehaviour
{

     [SerializeField] private ParticleSystem dustParticlePrefab;

     private ParticleSystem dustParticle;
     private float tiempo;
     private float tiempoEspera;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      // dustParticle = Instantiate(dustParticlePrefab, animator.GetComponent<Transform>().position, Quaternion.identity);
      // dustParticle.enabled = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if(tiempo < 0)
       {
            dustParticle = Instantiate(dustParticlePrefab, animator.transform.Find("ControladorDust").position, Quaternion.identity);
            tiempo = tiempoEspera;
       }
       else 
       {
            tiempo -= Time.deltaTime;
       }
       if(dustParticle != null)
       {
            dustParticle.Play();
       }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
