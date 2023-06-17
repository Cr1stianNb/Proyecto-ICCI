using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamara : MonoBehaviour
{

    public Transform jugador;

    public Transform farBackground, middleBackground;

    private Vector2 lastPos;

    public float alturaMin, alturaMax;

    // Start is called before the first frame update
    void Start()
    {
        
        lastPos = transform.position;

        jugador = GameObject.Find("Player").GetComponent<Transform>();
        farBackground = GameObject.Find("Far").GetComponent<Transform>();
        middleBackground = GameObject.Find("Middle").GetComponent<Transform>();
    }

    // Update is called once per frame

    void Update()
    {

       

        transform.position = new Vector3(jugador.position.x, Mathf.Clamp(jugador.position.y, alturaMin, alturaMax), transform.position.z);

      //  Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

//        farBackground.position = farBackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
  //      middleBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .8f;

    //    lastPos = transform.position;

    }
    
}
