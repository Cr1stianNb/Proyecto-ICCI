using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SistemaPausa : MonoBehaviour
{
    public GameObject menuPausa;
    private bool isPaused;

    private void Awake()
    {
        Time.timeScale = 1;
        menuPausa.SetActive(false);
        isPaused = false;
    }

    private void Update()
    {
        Pause();
    }

    private void Pause()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            isPaused = true;
            menuPausa.SetActive(true);
            Time.timeScale = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            isPaused = false;
            menuPausa.SetActive(false);
            Time.timeScale =  1;
        }
    }
}
