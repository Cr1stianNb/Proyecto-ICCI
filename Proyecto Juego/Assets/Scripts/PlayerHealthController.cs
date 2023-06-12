using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

   

    public int currentHealth, maxHealth;

    public float invincibleLength;

    private float invincibleCounter;

    private Transform checkpoint;

    public Transform player;

    //private SpriteRenderer theSR;

   

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
       // theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    /*
    void Update()
    {
        if(invincibleCounter > 0) 
        {
            invincibleCounter -= Time.deltaTime;
            if(invincibleCounter <= 0)
            {
                //theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
    }*/

    public void DealDamage()
    {   
        if(invincibleCounter <=0)
        {
            currentHealth--;
           // PlayerControler.instance.anim.SetTrigger("Hurt");


             if(currentHealth<=0)
            {
                currentHealth = 0;
              //  gameObject.SetActive(false);




            }
            else
            {
                //theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 0.5f);
                //invincibleCounter = invincibleLength;

                //PlayerController.instance.knockBack();
            }

        // UIControler.instance.UpdateHealthDisplay();
        }

    }
}

