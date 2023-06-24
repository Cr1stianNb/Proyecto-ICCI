using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoBola : MonoBehaviour
{
    public GameObject bola;
    public Transform controlador;

    public void dispararBola()
    {
        Instantiate(bola, controlador.position, controlador.rotation);
    }
}
