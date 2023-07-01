using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMeleeCombat : MonoBehaviour
{
  
    public ParticleSystem rayParticle;


    private void  Start()
    {
        Instantiate(rayParticle, transform.position, Quaternion.identity);
    }


    private void OnTriggerEnter2D(Collider2D player)
    {
        if(player.CompareTag("Player"))
        {
            Debug.Log("Upgrade triggered");
            CombateMele.canMeleCombat = true;
            Destroy(gameObject);

        }
    }
}
