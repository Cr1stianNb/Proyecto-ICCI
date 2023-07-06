using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SalidaScenes : MonoBehaviour
{
   public string sceneToLoad;
   public string exitName;

   private void OnTriggerEnter2D(Collider2D collider)
   {
      if( collider.tag == "Player")
      {
         PlayerScenes.destroyParent();
         PlayerPrefs.SetString("LastExitName", exitName);
         SceneManager.LoadScene(sceneToLoad);
      }
   }
}
