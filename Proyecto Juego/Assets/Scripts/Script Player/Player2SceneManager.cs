using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2SceneManager : MonoBehaviour
{
    public static Player2SceneManager instance;
    public  static  GameObject parent;
    public static ArrayList allParents = new ArrayList();
    public static bool isSecondPlayer = false;
  
    

    public static void destroyParent()
    {
        if(Player2SceneManager.instance.transform.parent != null)
        {
            Player2SceneManager.instance.transform.parent = null;
            DontDestroyOnLoad(Player2SceneManager.instance);
        }
        foreach(GameObject parent in allParents)
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
            allParents.Add(parent);
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
