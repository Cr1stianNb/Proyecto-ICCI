using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{

   public GameObject secondPlayer;
   public GameObject icon2;

   public void Jugar()
   {
      Player2SceneManager.isSecondPlayer = false;
      secondPlayer.SetActive(false);
      PlayerPrefs.SetString("LastExitName", "null");
      SceneManager.LoadScene(0);
   }

   public void Salir()
   {
    Debug.Log("Salir");
    Application.Quit();
   }
   public void Creditos()
   {
      SceneManager.LoadScene("Creditos ^^");   
   }

   public void Multijugador()
   {
      icon2.SetActive(true);
      Player2SceneManager.isSecondPlayer = true;
      secondPlayer.SetActive(true);
      PlayerPrefs.SetString("LastExitName", "null");
      SceneManager.LoadScene(0);
   }
}
  