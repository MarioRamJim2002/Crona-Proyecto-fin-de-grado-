using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacterPelea : MonoBehaviour
{

    public ControladorDatos controladorDatos;

    public int vidaTotal;
    public int vidaActual;
    public int nivel;
    public int expMaxima;
    public int expActual;
    public int defensa;
    public int ataque;
    public int velocidad;

    public Text textoVida; 
    public Text textoNivel;

    void Start(){
        
        controladorDatos = ControladorDatos.Instance;

        vidaTotal = controladorDatos.persVidaMaxima;
        vidaActual = controladorDatos.persVidaActual;
        nivel = controladorDatos.persNivel;
        expMaxima = controladorDatos.persExpMaxima;
        expActual = controladorDatos.persExpActual;
        defensa = controladorDatos.persDefensa;
        ataque = controladorDatos.persAtaque;
        velocidad = controladorDatos.persVelocidad;

    }

    void Update()
    {
        textoNivel.text = "Nivel " + nivel;
        textoVida.text = vidaActual + "/" + vidaTotal; 
    }
}
