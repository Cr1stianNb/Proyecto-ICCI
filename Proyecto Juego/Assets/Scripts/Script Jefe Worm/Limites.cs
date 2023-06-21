using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limites : MonoBehaviour
{
   public bool isRandom;
  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Boss"))
        {
           if(isRandom)
           {
                if(Random.Range(0,5) == 1)
                {
                    StartCoroutine(wait3Second(Random.Range(1,5)));
                    other.GetComponent<Animator>().SetTrigger("Limite");
                }
           }
           else 
           {
                Debug.Log("Entro");
                other.GetComponent<Animator>().SetTrigger("Limite");
           }
        }
    }

    private IEnumerator wait3Second(int n)
    {
        yield return  new WaitForSeconds(n);
    }


}
