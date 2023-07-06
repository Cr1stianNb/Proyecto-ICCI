using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{   

    public static AudioManager instance;

    public AudioSource[] soundEffects;

    public AudioSource bgm , levelEndMusic; 

    private void Awake()
    {
        //instance = this;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(int soundToPLay)
    {
        soundEffects[soundToPLay].Stop();
        soundEffects[soundToPLay].pitch = Random.Range(.9f,1.1f);
        soundEffects[soundToPLay].Play();
    }
}


//AudioManager.instace.PlaySFX(i);