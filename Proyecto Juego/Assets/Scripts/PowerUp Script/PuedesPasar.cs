using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuedesPasar: MonoBehaviour
{
    public GameObject bala; // Prefab del objeto que rompe la pared

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprobar si el objeto que colisiona es el prefab que puede romper la pared
        if (collision.gameObject.CompareTag("Bala") && collision.gameObject == bala)
        {
            BreakWall();
        }
    }

    private void BreakWall()
    {
        // Destruir la pared
        Destroy(gameObject);
    }
}
