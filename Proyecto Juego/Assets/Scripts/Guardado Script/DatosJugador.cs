using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class DatosJugador
{


    [Header("Escena")]
    public int buildIndexScene; 


    [Header("Puntaje")]

    public int puntaje;

    [Header("Jugador 1")]
    
    public Vector3 position;
    public bool canDoubleJump;
    public bool canWallJump;
    public bool canShot;
    public bool canMeleCombat;
    public int currentHealth;

    [Header("Jugador 2")]

    public Vector3 position2;
    public int currentHealth2;
    public bool isSecondPlayer;
    
}
