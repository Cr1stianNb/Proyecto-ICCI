using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntuacionManager : MonoBehaviour
{
    
    public static PuntuacionManager instance;

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
}
