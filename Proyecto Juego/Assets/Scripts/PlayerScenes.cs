using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScenes : MonoBehaviour
{
    
    public static PlayerScenes instance;

    void Start()
    {

        Debug.Log(PlayerPrefs.GetString("LastExitName"));

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

}
