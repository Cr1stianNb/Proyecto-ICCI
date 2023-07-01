using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMeleeCombat : MonoBehaviour
{
  
    //public Transform playerPosition;


    private void OnTriggerEnter2D(Collider2D player)
    {
        if(player.CompareTag("Player"))
        {
            Debug.Log("Upgrade triggered");
            CombateMele.canMeleCombat = true;
            //Instanciate(upgradeEffect, playerPosition);
            Destroy(gameObject);

        }
    }
}
