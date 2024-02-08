using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Random = UnityEngine.Random;

public enum CombatStatus{
        CHECK_FOR_VICTORY,
        NEXT_TURN
        
    }

public class LogicaPelea : MonoBehaviour
{

    
    public ControladorDatos controladorDatos;

    public FantasmaPelea enemigo;
    public MainCharacterPelea personajePrincipal;
    public Text textoPelea;
    
    public Button Ataque;
    public Button Bloqueo;
    public Button Curar;
    public Button Huir;

    private bool[] bloqueando = {false,false};
    public string accion = "";
    private CombatStatus combatStatus;
    private int turnoActual;
    private bool isCombatActive;

    void Start(){

        controladorDatos = ControladorDatos.Instance;

        Ataque.onClick.AddListener((delegate{AtaqueAcc();}));
        Bloqueo.onClick.AddListener((delegate{BloqueoAcc();}));
        Curar.onClick.AddListener((delegate{CurarAcc();}));
        Huir.onClick.AddListener((delegate{HuirAcc();}));

        this.turnoActual = 0;
        this.isCombatActive = true;
        this.combatStatus = CombatStatus.NEXT_TURN;
        StartCoroutine(this.combatLoop());
    
    }

    public void AtaqueAcc(){
        accion = "Atacar";
    }

     public void BloqueoAcc(){
        accion = "Bloquear";
    } 

    public void CurarAcc(){
        accion = "Curar";
    } 

    public void HuirAcc(){
        accion = "Huir";
    }

    IEnumerator combatLoop(){

        while(this.isCombatActive){

            switch(this.combatStatus){

                case CombatStatus.NEXT_TURN:
                    yield return new WaitForSeconds(1f);  
                    if(turnoActual == 0){

                        textoPelea.text = "Turno del jugador principal";

                        yield return new WaitUntil(() => accion != "");

                        if(accion == "Atacar"){
                        textoPelea.text = "Jugador principal ataca!";
                            yield return new WaitForSeconds(1f);  

                            if(bloqueando[1] == true){

                                yield return new WaitForSeconds(1f);  
                                textoPelea.text = "Pero el fantasma bloquea el ataque!";
   
                            }else{

                                enemigo.vidaActual = (int)(enemigo.vidaActual - Math.Round((double)(personajePrincipal.ataque - (enemigo.defensa/4 ))));
                                if(enemigo.vidaActual < 0 ){
                                    enemigo.vidaActual = 0;
                                }
                            }
                        }

                        if(accion == "Bloquear"){
                            yield return new WaitForSeconds(1f);  
                            textoPelea.text = "El jugador principal esta bloqueando";
                            bloqueando[0] = true;

                        }

                        if(accion == "Curar"){
                            yield return new WaitForSeconds(1f);  
                            textoPelea.text = "El jugador principal se ha sanado";
                            personajePrincipal.vidaActual += 6;

                        }

                        if(accion == "Huir"){
                            isCombatActive = false;
                            SceneManager.LoadScene("Escena Principal");

                        }
                        if(bloqueando[1] == true){
                            yield return new WaitForSeconds(1f);  
                            textoPelea.text = "El fantasma ya no esta bloqueando";
                            bloqueando[1] = false;
                        }
                    turnoActual = 1;
                    accion = "";
                    }else if(turnoActual==1){
                        yield return new WaitForSeconds(1f);  
                        textoPelea.text = "Turno del fantasma";

                        int opcion = Random.Range(1,3);

                        if(opcion == 1){
                            yield return new WaitForSeconds(1f);  
                            textoPelea.text = "El fantasma ataca!";

                            if(bloqueando[0] == true){      

                                yield return new WaitForSeconds(1f);  
                                textoPelea.text = "Pero el jugador principal bloquea el ataque!";

                                enemigo.transform.Translate(-10f * Time.deltaTime,0,0);
                                enemigo.transform.Translate(10f * Time.deltaTime,0,0);
                                
                            }else{

                                personajePrincipal.vidaActual = (int)(personajePrincipal.vidaActual - Math.Round((double)(enemigo.ataque - (personajePrincipal.defensa/4 ))));
                                if(personajePrincipal.vidaActual < 0 ){
                                    personajePrincipal.vidaActual = 0;
                                }
                                enemigo.transform.Translate(-10f * Time.deltaTime,0,0);
                                enemigo.transform.Translate(10f * Time.deltaTime,0,0);

                            }

                        }else{                            
                            yield return new WaitForSeconds(1f);  
                            textoPelea.text = "El fantasma esta bloqueando";

                            bloqueando[1] = true;

                        }
                        if(bloqueando[0] == true){
                        
                        yield return new WaitForSeconds(1f); 
                        textoPelea.text = "El jugador principal ya no esta bloqueando";
                        bloqueando[0] = false;

                        }
                        turnoActual = 0;

                    }

                        combatStatus = CombatStatus.CHECK_FOR_VICTORY;
                        yield return null; 
                        break;
                
                case CombatStatus.CHECK_FOR_VICTORY:
                    controladorDatos.persVidaActual = personajePrincipal.vidaActual;
                    controladorDatos.persVidaMaxima = personajePrincipal.vidaTotal;
                    if(enemigo.vidaActual == 0){
                        textoPelea.text = "Has ganado la pelea!";
                        subirExp(enemigo.exp);
                        yield return new WaitForSeconds(1f); 
                            SceneManager.LoadScene("Escena Principal");

                    }
                    if(personajePrincipal.vidaActual == 0){
                        textoPelea.text = "Has perdido la pelea!";
                        yield return new WaitForSeconds(1f); 
                        SceneManager.LoadScene("Escena Principal");

                    }
                        combatStatus = CombatStatus.NEXT_TURN;
                        yield return null; 
                        break;
            }
        }
    }
            public void subirExp(int puntos){

                    controladorDatos.persExpActual += puntos;

                    if(controladorDatos.persExpActual >=  controladorDatos.persExpMaxima){

                        controladorDatos.persExpActual -= controladorDatos.persExpMaxima;
                        controladorDatos.persNivel += 1;
                        controladorDatos.persVidaMaxima += 3;
                        controladorDatos.persVidaActual += 3;
                        controladorDatos.persDefensa += 2;
                        controladorDatos.persAtaque += 2;
                        controladorDatos.persVelocidad += 2;

                        controladorDatos.persExpMaxima = (int)(controladorDatos.persExpMaxima * 1.2); 
                        controladorDatos.persExpMaxima = (int)(Mathf.Round((float)controladorDatos.persExpMaxima));

                    }
                }
}
