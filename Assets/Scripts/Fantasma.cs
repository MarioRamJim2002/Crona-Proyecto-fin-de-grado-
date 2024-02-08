using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fantasma : MonoBehaviour
{

    public ControladorDatos controladorDatos;

    public int vidaActual = 17;
    public int vidaTotal = 17;
    public int ataque = 7;
    public int defensa = 1;
    public int velocidad = 10;
    public int exp = 125;
    public int nivel = 3;

    void Start(){
                
        controladorDatos = ControladorDatos.Instance;
        
        if(controladorDatos.isDestroyed == true){

            Destroy(this.gameObject);

        }
    }
    
    void Update() {
        if(controladorDatos.isDestroyed == true){

                    Destroy(this.gameObject);

                }
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.CompareTag("Player")){

            controladorDatos.enemVida = vidaActual;
            controladorDatos.enemAtaque = ataque;
            controladorDatos.enemDefensa = defensa;
            controladorDatos.enemExp = exp;
            controladorDatos.enemVelocidad = velocidad; 
            controladorDatos.enemNivel = nivel;
            controladorDatos.isDestroyed = true;
            controladorDatos.tieneInfo = true;

            SceneManager.LoadScene("Escena Pelea");

        }

    }

}
