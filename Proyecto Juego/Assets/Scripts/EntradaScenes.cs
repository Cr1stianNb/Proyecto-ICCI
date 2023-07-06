using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntradaScenes : MonoBehaviour
{
   public string LastExitName;

   void Start()
   {
        if( PlayerPrefs.GetString("LastExitName") == LastExitName)
        {
            Debug.Log(PlayerPrefs.GetString("LastExitName"));
            PlayerScenes.instance.transform.position = transform.position;
        }
   }
}
