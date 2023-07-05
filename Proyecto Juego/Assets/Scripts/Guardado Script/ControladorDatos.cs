using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System;
public class ControladorDatos : MonoBehaviour
{
   private static ControladorDatos instance;
   public GameObject[] jugadores;
   public string archivoDeGuardado;
   public DatosJugador datosJugador = new DatosJugador();
   


   private void Awake()
   {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
        archivoDeGuardado = Application.dataPath + "/datosJuego.json";
        jugadores = GameObject.FindGameObjectsWithTag("Player");
   }


   private void Start()
   {
        SistemaGuardado.OnSaved += GuardarDatos;
        SistemaGuardado.OnLoad += CargarDatos;
   }


  

   private void CargarDatos(object sender, EventArgs e)
   {
        if(File.Exists(archivoDeGuardado))
        {
           string contenido = File.ReadAllText(archivoDeGuardado);
           datosJugador = JsonUtility.FromJson<DatosJugador>(contenido);

           FirstPlayer().transform.position = datosJugador.position;
           SceneManager.LoadScene(datosJugador.buildIndexScene);
        }
        else 
        {
            Debug.Log("No existe el archivo");
        }
   }
   private void GuardarDatos(object sender, EventArgs e)
   {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        DatosJugador nuevosDatos = new DatosJugador()
        {
            position = FirstPlayer().transform.position,
            buildIndexScene = currentSceneIndex

        };

        string cadenaJson = JsonUtility.ToJson(nuevosDatos);

        File.WriteAllText(archivoDeGuardado, cadenaJson);

        Debug.Log("Archivo guardado");
   }

   private GameObject FirstPlayer()
   {
        foreach(GameObject player in jugadores)
        {
            if(player.GetComponent<PlayerScenes>() != null)
            {
                return player;
            }
        }

        return null;
   }

    private GameObject SecondPlayer()
   {
        foreach(GameObject player in jugadores)
        {
            if(player.GetComponent<PlayerScenes>() == null)
            {
                return player;
            }
        }

        return null;
   }
}
