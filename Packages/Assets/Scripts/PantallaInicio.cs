using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PantallaInicio : MonoBehaviour
{
   
     public Button botonPartidaNueva;
     public Button botonCargarPartida;
     public Button botonSalir;

     public ControladorDatos controladorDatos;

     void Start()
     {   
          controladorDatos = ControladorDatos.Instance;
          botonPartidaNueva.onClick.AddListener(delegate{partidaNueva();});
          botonCargarPartida.onClick.AddListener(delegate{cargarPartida();});
          botonSalir.onClick.AddListener(delegate{salir();});

     }

     public void cargarPartida(){

          controladorDatos.cargarDatos();
          SceneManager.LoadScene("Escena Principal");

     }

     public void partidaNueva(){

          SceneManager.LoadScene("Introducción");

     }

     public void salir(){

          Application.Quit();

     }
}
