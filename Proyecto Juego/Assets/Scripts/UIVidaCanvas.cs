using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIVidaCanvas : MonoBehaviour
{
    public static UIVidaCanvas instance;
    //public Image hearth, hearth2, hearth3, hearth4, hearth5;
    public Sprite hearthFull, hearthEmpty;

    private void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthDisplay()
    {
        /*switch(PlayerHealthController.instance.currentHealth)
        {
            case 5:
                hearth.sprite = hearthFull;
                hearth2.sprite = hearthFull;
                hearth3.sprite = hearthFull;
                hearth4.sprite = hearthFull;
                hearth5.sprite = hearthFull;

                break;
            case 4:
                hearth.sprite = hearthFull;
                hearth2.sprite = hearthFull;
                hearth3.sprite = hearthFull;
                hearth4.sprite = hearthFull;
                hearth5.sprite = hearthEmpty;

                break;
            case 3:
                hearth.sprite = hearthFull;
                hearth2.sprite = hearthFull;
                hearth3.sprite = hearthFull;
                hearth4.sprite = hearthEmpty;
                hearth5.sprite = hearthEmpty;

                break;
            case 2:
                hearth.sprite = hearthFull;
                hearth2.sprite = hearthFull;
                hearth3.sprite = hearthEmpty;
                hearth4.sprite = hearthEmpty;
                hearth5.sprite = hearthEmpty;

                break;
            case 1:
                hearth.sprite = hearthFull;
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
        } */
        
    }
}
