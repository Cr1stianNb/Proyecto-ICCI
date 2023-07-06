using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;



public class MenuReiniciar : MonoBehaviour
{
    public GameObject menu;
    public GameObject[] players;
   // public PlayerHealthController controladorHealth;

    public  UnityEvent OnBegin, OnDone;
   
    private void Start()
    {
        PlayerHealthController.MuerteJugador += AbrirMenu;
        players = GameObject.FindGameObjectsWithTag("Player");

    }

    private void Update()
    {
        if(!isPlayer())
        {
            players = GameObject.FindGameObjectsWithTag("Player");

        }
    }

    public bool isPlayer()
    {
        foreach(GameObject player in players)
        {
            if(player == null)
            {
                return false;
            }
        }

        return true;

    }


    private void AbrirMenu(object sender, EventArgs e)
    {
        
        if(menu != null)
        {
            PlayerScenes.destroyParent();
            menu.SetActive(true);
            Time.timeScale = 0;
            OnBegin?.Invoke();
        }
       
    }

    public void RecuperarSalud()
    {
        foreach(GameObject player in players)
        {
            player.GetComponent<PlayerHealthController>().RecuperarTodaLaSalud();
        }
    }

    public  void InvokeOnBegin()
    {
        //OnBegin?.Invoke();
    }


   public void Reiniciar()
   {
    // mejorar esto
        
        Time.timeScale = 1;
        OnDone?.Invoke();
        menu.SetActive(false);
        StartCoroutine(delayIgnoreLayer());
        RecuperarSalud();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
        
       // controladorHealth.estaMuerto = false;
       // controladorHealth.currentHealth = controladorHealth.maxHealth;
       // controladorHealth.animator.SetTrigger("Muerte");
       // controladorHealth.rb2D.constraints = RigidbodyConstraints2D.None;
       // controladorHealth.rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        //Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("Enemigo"),false);
   }

   public IEnumerator delayIgnoreLayer()
   {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("Enemigo"),true );
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("Enemigo"),false);
   }
}
