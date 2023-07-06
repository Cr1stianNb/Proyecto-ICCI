using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HongoSFX : MonoBehaviour
{
    public void StartSFXHongo()
    {
        AudioManager.instance.PlaySFX(10);
    }
}
