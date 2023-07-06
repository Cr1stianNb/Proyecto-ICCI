using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
   public void Jugar()
   {
      PlayerPrefs.SetString("LastExitName", "null");
      SceneManager.LoadScene(0);
   }

   public void Salir()
   {
    Debug.Log("Salir");
   // Aplication.Quit();
   }
   public void Creditos()
   {
      SceneManager.LoadScene("Creditos ^^");   
   }
}
  