using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2SceneManager : MonoBehaviour
{
    public static Player2SceneManager instance;

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

    void Update()
    {
        if(transform.parent == null)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

}
