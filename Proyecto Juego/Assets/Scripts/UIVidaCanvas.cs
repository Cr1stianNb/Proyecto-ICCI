using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIVidaCanvas : MonoBehaviour
{
    public static UIVidaCanvas instance;
    public Image hearth, hearth2, hearth3, hearth4, hearth5;
    public Sprite hearthFull, hearthEmpty, hearthHalfe;

    private void Awake()
    {
        instance = this;
    }
    
  
    public void UpdateHealthDisplay()
    {
        switch(GameObject.FindObjectOfType<PlayerScenes>().GetComponent<PlayerHealthController>().currentHealth)
        {
            case 10:
                hearth.sprite = hearthFull;
                hearth2.sprite = hearthFull;
                hearth3.sprite = hearthFull;
                hearth4.sprite = hearthFull;
                hearth5.sprite = hearthFull;

                break;
            case 9:
                hearth.sprite = hearthFull;
                hearth2.sprite = hearthFull;
                hearth3.sprite = hearthFull;
                hearth4.sprite = hearthFull;
                hearth5.sprite = hearthHalfe;

                break;
            case 8:
                hearth.sprite = hearthFull;
                hearth2.sprite = hearthFull;
                hearth3.sprite = hearthFull;
                hearth4.sprite = hearthFull;
                hearth5.sprite = hearthEmpty;

                break;
            case 7:
                hearth.sprite = hearthFull;
                hearth2.sprite = hearthFull;
                hearth3.sprite = hearthFull;
                hearth4.sprite = hearthHalfe;
                hearth5.sprite = hearthEmpty;

                break;

            case 6:
                hearth.sprite = hearthFull;
                hearth2.sprite = hearthFull;
                hearth3.sprite = hearthFull;
                hearth4.sprite = hearthEmpty;
                hearth5.sprite = hearthEmpty;

                break;
            case 5:
                hearth.sprite = hearthFull;
                hearth2.sprite = hearthFull;
                hearth3.sprite = hearthHalfe;
                hearth4.sprite = hearthEmpty;
                hearth5.sprite = hearthEmpty;

                break;
            case 4:
                hearth.sprite = hearthFull;
                hearth2.sprite = hearthFull;
                hearth3.sprite = hearthEmpty;
                hearth4.sprite = hearthEmpty;
                hearth5.sprite = hearthEmpty;

                break;       
            case 3:
                hearth.sprite = hearthFull;
                hearth2.sprite = hearthHalfe;
                hearth3.sprite = hearthEmpty;
                hearth4.sprite = hearthEmpty;
                hearth5.sprite = hearthEmpty;

                break;
            case 2:
                hearth.sprite = hearthFull;
                hearth2.sprite = hearthEmpty;
                hearth3.sprite = hearthEmpty;
                hearth4.sprite = hearthEmpty;
                hearth5.sprite = hearthEmpty;

                break;
            case 1:
                hearth.sprite = hearthHalfe;
                hearth2.sprite = hearthEmpty;
                hearth3.sprite = hearthEmpty;
                hearth4.sprite = hearthEmpty;
                hearth5.sprite = hearthEmpty;

                break;
            case 0:
                hearth.sprite = hearthEmpty;
                hearth2.sprite = hearthEmpty;
                hearth3.sprite = hearthEmpty;
                hearth4.sprite = hearthEmpty;
                hearth5.sprite = hearthEmpty;

                break;
            default:
                hearth.sprite = hearthEmpty;
                hearth2.sprite = hearthEmpty;
                hearth3.sprite = hearthEmpty;
                hearth4.sprite = hearthEmpty;
                hearth5.sprite = hearthEmpty;

                break;
        } 
        
    }
}
