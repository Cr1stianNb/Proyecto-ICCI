using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeDemon : JefeWorm
{
  
    private void Start()
    {
        mitadVida = GetComponent<Enemigo>().vida / 2f;
        theSR = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        theRB = GetComponent<Rigidbody2D>();
        jugadores = GameObject.FindGameObjectsWithTag("Player");
    }
}
