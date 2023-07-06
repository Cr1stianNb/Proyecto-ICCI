using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{

 
   public GameObject icon2;
   public GameObject secondPlayer;
   
   private void Start()
   {

      icon2 = getIcon2();
      secondPlayer = Player2SceneManager.instance.gameObject;


   }

   public void Jugar()
   {
      if (secondPlayer != null)
      {
         Player2SceneManager.isSecondPlayer = false;
         secondPlayer.SetActive(false);
         icon2.SetActive(false);
      }
      PlayerPrefs.SetString("LastExitName", "null");
      SceneManager.LoadScene(2);
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
      if(secondPlayer != null)
      {
         icon2.SetActive(true);
         Player2SceneManager.isSecondPlayer = true;
         secondPlayer.SetActive(true);
      }
      PlayerPrefs.SetString("LastExitName", "null");
      SceneManager.LoadScene(2);
   }

   public GameObject getIcon2()
   {
      GameObject[] list = FindObjectsOfType<GameObject>(true);

      foreach(GameObject o in list)
      {
         if(o.CompareTag("Icono2"))
         {
            return o;
         }
      }
      return null;
   }
}
  