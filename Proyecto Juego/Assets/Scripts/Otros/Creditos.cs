using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Creditos : MonoBehaviour
{
    
    void Start()
    {
        invoke("WaitToEnd",25);
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
           SceneManagement.LoadScene("MainMenu"); //Se debe cambiar el nombre en caso de 
        }
    }

    public void WaitToEnd()
    {
        SceneManagement.LoadScene("MainMenu"); //Se debe cambiar el nombre en caso de
    }
}
