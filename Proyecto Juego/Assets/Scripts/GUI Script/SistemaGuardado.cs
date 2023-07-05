using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class SistemaGuardado : MonoBehaviour
{


    public static  event  EventHandler OnSaved , OnLoad;


    public void Cargar()
    {
        OnLoad?.Invoke(this, EventArgs.Empty);
    }


    public void Guardar()
    {
        OnSaved?.Invoke(this, EventArgs.Empty);
    }
}
