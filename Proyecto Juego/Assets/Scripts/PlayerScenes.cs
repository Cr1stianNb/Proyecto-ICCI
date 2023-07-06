using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScenes : MonoBehaviour
{
    
    public static PlayerScenes instance;
    public  static  GameObject parent;

    public static void destroyParent()
    {
        if(PlayerScenes.instance.transform.parent != null)
        {
            PlayerScenes.instance.transform.parent = null;
            DontDestroyOnLoad(PlayerScenes.instance);
        }
        if(parent != null)
        {
            Destroy(parent);
        }
    }

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


    void Update()
    {
        if(transform.parent != null)
        {
            parent = GetRootGameObject(transform.parent);
            DontDestroyOnLoad(parent);
        }
       
        
        
    }

    GameObject GetRootGameObject(Transform childTransform)
    {
        Transform currentTransform = childTransform;

        while (currentTransform.parent != null)
        {
            currentTransform = currentTransform.parent;
        }

        return currentTransform.gameObject;
    }


}
