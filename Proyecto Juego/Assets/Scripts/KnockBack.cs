using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockBack : MonoBehaviour
{
    
    
    [SerializeField] private Rigidbody2D theRB;
    [SerializeField] private float strength = 26f, delay = 1f;
    
    public UnityEvent OnBegin, OnDone;




    public void knockBack( Transform sender)
    {
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position - sender.position).normalized;
        theRB.AddForce(direction*strength, ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }



    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
        theRB.velocity = Vector3.zero;
        OnDone?.Invoke();
    }
}