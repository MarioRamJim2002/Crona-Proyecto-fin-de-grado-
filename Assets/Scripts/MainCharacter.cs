using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCharacter : MonoBehaviour{

    public Animator animator;

    public Text textoVida;
    public Text textoExperiencia;
    public Text textoNivel;

    public Text statsVida;
    public Text statsExp;
    public Text statsAtaque;
    public Text statsDefensa;
    public Text statsVelocidad;

    private MenusManager menusManager;
    public ControladorDatos controladorDatos;

    public int vidaTotal = 21;
    public int vidaActual = 20; 

    public double expSiguienteNivel = 100; 
    public double expActual = 0;
    public int nivel = 1;

    public int ataque = 5;
    public int defensa = 4;
    public int velocidad = 9;

    private int objetoSeleccionado = -1;

    void Start(){
        
        statsAtaque.text = "Ataque: "+ataque;
        statsDefensa.text = "Defensa: "+defensa;
        statsVelocidad.text = "Velocidad: "+velocidad;
        statsExp.text = "Exp: "+expActual+"/"+expSiguienteNivel;
        statsVida.text = "Vida: "+vidaActual+"/"+vidaTotal;

        controladorDatos = ControladorDatos.Instance;
        menusManager = GetComponent<MenusManager>(); 
        
        if(controladorDatos.tieneInfo){

            ataque = controladorDatos.persAtaque;
            defensa = controladorDatos.persDefensa;
            velocidad = controladorDatos.persVelocidad;
            nivel = controladorDatos.persNivel;
            expActual = controladorDatos.persExpActual;
            expSiguienteNivel = controladorDatos.persExpMaxima;
            vidaActual = controladorDatos.persVidaActual;
            vidaTotal = controladorDatos.persVidaMaxima;
            textoVida.text = vidaActual+"/"+vidaTotal;
            textoExperiencia.text = expActual+"/"+expSiguienteNivel;
            textoNivel.text = "Nivel " + nivel;
            transform.position = new Vector3(controladorDatos.x, controladorDatos.y, 0);
        }
        
    }

  private void OnTriggerEnter2D(Collider2D collision){

        if(collision.tag == "Npc"){

            //Destroy(this.gameObject);

        }

    }  


    public void curarVida(int cantidad){

        if(vidaActual != vidaTotal){

            vidaActual += cantidad;

            if(vidaActual >= vidaTotal){

                vidaActual = vidaTotal;

            }

        }

        textoVida.text = vidaActual+"/"+vidaTotal;

    }

    public void recibirDaño(int daño){

        if((vidaActual -= daño) <= 0){

            vidaActual = 0;

        }else{

            vidaActual -= daño;

        }

        textoVida.text = vidaActual+"/"+vidaTotal;

    }

    public void subirExp(double puntos){

        expActual += puntos;

        if(expActual >= expSiguienteNivel){

            expActual -= expSiguienteNivel;
            nivel += 1;
            vidaTotal += 3;
            vidaActual += 3;
            defensa += 2;
            ataque += 2;
            velocidad += 2;
            
            textoNivel.text = "Nivel " + nivel;


            expSiguienteNivel = expSiguienteNivel * 1.2; 
            expSiguienteNivel = Mathf.Round((float)expSiguienteNivel);
        
            textoVida.text = vidaActual+"/"+vidaTotal;

        }

        textoExperiencia.text = expActual+"/"+expSiguienteNivel;

    }



    void Update(){

        controladorDatos.persVidaMaxima = vidaTotal;
        controladorDatos.persVidaActual = vidaActual;
        controladorDatos.persExpMaxima = (int)expSiguienteNivel;
        controladorDatos.persExpActual = (int)expActual;
        controladorDatos.persAtaque = ataque;
        controladorDatos.persDefensa = defensa;
        controladorDatos.persVelocidad = velocidad;
        controladorDatos.persNivel = nivel;
        controladorDatos.x = (int)transform.position.x;
        controladorDatos.y = (int)transform.position.y; 

        if(menusManager.isShowingAlgo){
            
        }else{

            if(Input.GetKey("up")||Input.GetKey("w")){

                gameObject.transform.Translate(0, 4f * Time.deltaTime,0);
                animator.Play("Walk_up");

            }else{

                if(Input.GetKey("down")||Input.GetKey("s")){

                    gameObject.transform.Translate(0, -4f * Time.deltaTime,0);
                    animator.Play("Walk_down");

                }else{

                    if(Input.GetKey("right")||Input.GetKey("d")){

                    gameObject.transform.Translate(4f * Time.deltaTime,0,0);
                    animator.Play("Walk_right");

                    }else{

                        if(Input.GetKey("left")||Input.GetKey("a")){

                            gameObject.transform.Translate(-4f * Time.deltaTime,0,0);
                            animator.Play("Walk_left");

                        }else{
                            animator.Play("Idle");
                        }

                    }
                }
            }
        }
    }
}
