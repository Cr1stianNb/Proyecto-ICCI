using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private  void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerHealthController>().DealDamage(999);
                
        }
        else if(other.tag == "Enemigo")
        {
            other.GetComponent<Enemigo>().TomarDanio(9999);
        }
    }
}
