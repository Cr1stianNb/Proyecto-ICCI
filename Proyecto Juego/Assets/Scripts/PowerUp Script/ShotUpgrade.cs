using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotUpgrade : MonoBehaviour
{

    public ParticleSystem rayParticle;

    private void  Start()
    {
        Instantiate(rayParticle, transform.position, Quaternion.identity);
    }

   
    private void OnTriggerEnter2D(Collider2D player)
    {
        if(player.tag == "Player")
        {
            Debug.Log("Upgrade triggered");
            DisparoPlayer.canShot = true;
            //Instanciate(upgradeEffect, playerPosition);
            Destroy(gameObject);

        }
    }
}
