using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrasManager : MonoBehaviour
{

    public Image barraDeVida;
    public Image barraDeExp;
    public GameObject personajePrincipal;

    private MainCharacter mainCharacter;

    private float vidaActual;
    private float vidaTotal;

    private float expActual;
    private float expSiguienteNivel;

    void Start(){

        mainCharacter = personajePrincipal.GetComponent<MainCharacter>(); 

        vidaActual = (float)mainCharacter.vidaActual;
        vidaTotal = (float)mainCharacter.vidaTotal;

        expActual = (float)mainCharacter.expActual;
        expSiguienteNivel = (float)mainCharacter.expSiguienteNivel;
        
    }

    void Update(){

        vidaActual = (float)mainCharacter.vidaActual;
        vidaTotal = (float)mainCharacter.vidaTotal;

        expActual = (float)mainCharacter.expActual;
        expSiguienteNivel = (float)mainCharacter.expSiguienteNivel;

        barraDeVida.fillAmount = vidaActual/vidaTotal;
        barraDeExp.fillAmount = expActual/expSiguienteNivel;

    }
}
