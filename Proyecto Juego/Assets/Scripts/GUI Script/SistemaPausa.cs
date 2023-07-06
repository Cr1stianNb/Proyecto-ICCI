using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SistemaPausa : MonoBehaviour
{
    public GameObject menuPausa;
    public static bool isPaused;
    public GameObject player;
    public UnityEvent OnMenu, ExitMenu;

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
            OnMenu?.Invoke();
            isPaused = true;
            menuPausa.SetActive(true);
            Time.timeScale = 0f;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            SalirMenuPausa();
        }
    }

    public void SalirMenuPausa()
    {
        StartCoroutine(Delay());
        isPaused = false;
        menuPausa.SetActive(false);
        Time.timeScale = 1;
    }

    public void IrMenuPrincipal()
    {
        //Destroy(player);
        SalirMenuPausa();
        SceneManager.LoadScene(51);
        

    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Prueba");
        ExitMenu?.Invoke();
    }
}
