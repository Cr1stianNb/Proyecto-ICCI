using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class ControladorDatos : MonoBehaviour
{
   public GameObject jugador;
   public string archivoDeGuardado;
   public DatosJugador datosJugador = new DatosJugador();


   private void Awake()
   {
        archivoDeGuardado = Application.dataPath + "/datosJuego.json";

        jugador = GameObject.FindGameObjectWithTag("Player");
   }


   private void Update()
   {
        if(Input.GetKeyDown(KeyCode.S))
        {
            CargarDatos();
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            GuardarDatos();
        }
   }

   private void CargarDatos()
   {
        if(File.Exists(archivoDeGuardado))
        {
           string contenido = File.ReadAllText(archivoDeGuardado);
           datosJugador = JsonUtility.FromJson<DatosJugador>(contenido);

           jugador.transform.position = datosJugador.posicion;
        }
        else 
        {
            Debug.Log("No existe el archivo");
        }
   }
   private void GuardarDatos()
   {
        DatosJugador nuevosDatos = new DatosJugador()
        {
            posicion = jugador.transform.position
        };

        string cadenaJson = JsonUtility.ToJson(nuevosDatos);

        File.WriteAllText(archivoDeGuardado, cadenaJson);

        Debug.Log("Archivo guardado");
   }
}
