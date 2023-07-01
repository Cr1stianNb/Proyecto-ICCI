using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeWallJump : MonoBehaviour
{
    // public ParticleSystem upgradeEffect;
    // public Transform playerPosition;


    private void OnTriggerEnter2D(Collider2D player)
    {
        if(player.tag == "Player")
        {
            Debug.Log("Upgrade triggered");
            PlayerController.canWallJump = true;
            //Instanciate(upgradeEffect, playerPosition);
            Destroy(gameObject);

        }
    }
}
