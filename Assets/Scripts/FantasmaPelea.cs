using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FantasmaPelea : MonoBehaviour
{
    public ControladorDatos controladorDatos;

    public int vidaMaxima;
    public int vidaActual;
    public int ataque;
    public int defensa;
    public int velocidad;
    public int exp;
    public int nivel;

    public Text textoVida;
    public Text textoNivel;


    void Start(){

        controladorDatos = ControladorDatos.Instance;
    
        vidaMaxima = controladorDatos.enemVida;    
        vidaActual = controladorDatos.enemVida;
        ataque = controladorDatos.enemAtaque;
        defensa = controladorDatos.enemDefensa;
        velocidad = controladorDatos.enemVelocidad;
        exp = controladorDatos.enemExp;
        nivel = controladorDatos.enemNivel;
  
    }

    void Update(){
        textoNivel.text = "Nivel " + nivel;
        textoVida.text = vidaActual + "/" + vidaMaxima;   
    }
}
