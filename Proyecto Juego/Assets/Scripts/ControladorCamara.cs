using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamara : MonoBehaviour
{

    public Transform jugador;

    public static ControladorCamara instance;

    public float alturaMin, alturaMax;

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame

    void Update()
    {

       

        transform.position = new Vector3(jugador.position.x, Mathf.Clamp(jugador.position.y, alturaMin, alturaMax), transform.position.z);


    }
    
}
