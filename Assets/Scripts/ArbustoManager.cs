using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArbustoManager : MonoBehaviour
{
    public Sprite arbustoRecogido;
    public MainCharacter mainCharacter;
    public Text textoRecoger;
    private bool recogido = false; 
    void Start()
    {


    }

    void OnTriggerEnter2D(Collider2D colision)
    {
        if(recogido == false){
            textoRecoger.text = "Pulsa E para recoger el objeto";
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {   
        if(recogido == false){
            textoRecoger.text = "";
        }
    }
    void Update()
    {
        if(recogido == false){
            if(textoRecoger.text !=""){
                if(Input.GetKeyDown("e")){
                    textoRecoger.text = "";
                    recogido = true;
                    mainCharacter.menusManager.cantidadObjetos[2]+=1;
                    mainCharacter.menusManager.CambiarInventario("O");
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = arbustoRecogido;
                }
            }
        } 
    }
}
