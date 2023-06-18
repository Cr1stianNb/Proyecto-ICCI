using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;




public class MenuReiniciar : MonoBehaviour
{
    public GameObject menu;
    private PlayerHealthController controladorHealth;

   
    private void Start()
    {
        controladorHealth = GameObject.Find("Player").GetComponent<PlayerHealthController>();
        controladorHealth.MuerteJugador += AbrirMenu;
    }


    private void AbrirMenu(object sender, EventArgs e)
    {
        menu.SetActive(true);
    }

   public void Reiniciar()
   {
    

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        controladorHealth.estaMuerto = false;
        controladorHealth.currentHealth = controladorHealth.maxHealth;
        controladorHealth.animator.SetTrigger("Muerte");
        menu.SetActive(false);
        controladorHealth.rb2D.constraints = RigidbodyConstraints2D.None;
        controladorHealth.rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        //Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("Enemigo"),false);
   }
}
