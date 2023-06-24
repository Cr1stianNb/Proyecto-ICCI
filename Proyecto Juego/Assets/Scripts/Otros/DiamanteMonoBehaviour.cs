using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamanteMonoBehaviour : MonoBehaviour
{
   
   public GameObject particulaShine;
   private Animator animator;


   private void Start()
   {
        animator = GetComponent<Animator>();
   }

   public void IsFinish()
   {
        animator.SetBool("isFinish", true);
   }

   public void DoSetActiveParticleTrue()
   {
          particulaShine.SetActive(true);

   }

   public void DoSetActiveParticleFalse()
   {
          particulaShine.SetActive(false);
   }

   private void OnTriggerEnter2D(Collider2D collider)
   {
     if(collider.CompareTag("Player"))
     {

          Destroy(gameObject);
          DoSetActiveParticleFalse();
     }
   }





}
