using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenusManager : MonoBehaviour{

    public MainCharacter personajePrincipal;

    public Button iconoMenu;
    public Button iconoInventario;
    public Button iconoStats;
    public Button iconoSalir;
    public Button iconoVolver;
    public Button botonObjetos;
    public Button botonEquipamiento;
    
    public Button[] botonesInventario;
    public Text[] cantidadInventario;
    public Image[] imagenesIcono;
    public Text[] descripcionTextos;

    public GameObject menu;
    public GameObject inventario;
    public GameObject stats;
    public GameObject interfaz;

    public bool isShowingAlgo;

    public string[] nombresObjetos;
    public string[] descripcionObjetos;
    public int[] cantidadObjetos;
    public Text[] cantidadObjetosText;
    public Texture[] imagenesObjetos;

    public string[] nombresEquipamiento;
    public string[] descripcionEquipamiento;
    public bool[] tieneEquipamiento;
    public Texture[] imagenesEquipamiento;
    
    public Image imagenInventario;
    public Text textoDescripcion;
    public Text textoObjeto;
    
    public Button botonUsar;

    private string menuActual;
    //public Objeto objetoSeleccionado;
    public string nombreObjetoTexto;
    
    void Start(){

        nombresObjetos[0] = "Seta roja";
        nombresObjetos[1] = "Pocion exp pequeña";
        nombresObjetos[2] = "Baya roja";
        descripcionObjetos[0] = "Seta roja que se puede encontrar en la naturaleza. Se puede consumir para recuperar 10 puntos de vida";
        descripcionObjetos[1] = "Poción de experiencia de tamaño pequeño. Se puede consumir para conseguir 100 puntos de experiencia"; 
        descripcionObjetos[2] = "Baya roja bastante común en el bosque de Talior. Pueden ser de valor en algunos lugares ya que es autoctona de esta zona"; 
        cantidadObjetos[0] = 2;
        cantidadObjetos[1] = 2;
        cantidadObjetos[2] = 0;
        cantidadObjetosText[0].text = "x" + cantidadObjetos[0];
        cantidadObjetosText[1].text = "x" + cantidadObjetos[1];
        cantidadObjetosText[2].text = "x" + cantidadObjetos[1];
        nombresEquipamiento[0] = "Espada de hierro";
        nombresEquipamiento[1] = "Espada de fuego";
        nombresEquipamiento[2] = "Armadura de cuero";
        nombresEquipamiento[3] = "Armadura de Hierro";
        descripcionEquipamiento[0] = "Espada de hierro básica. Esta espada no tiene nada especial, pero está en buenas condiciones";
        descripcionEquipamiento[1] = "Espada de fuego encontrada en algun lugar del bosque. Puede quemar a los oponentes si se tiene equipada";
        descripcionEquipamiento[2] = "Armadura de cuero básica. Esta armadura no tiene nada especial, pero cumple su trabajo";
        descripcionEquipamiento[3] = "Armadura de hierro encontrada en algun lugar del bosque. Puede bloquear ataques si se tiene equipada";
        tieneEquipamiento[0] = true;
        tieneEquipamiento[1] = false;
        tieneEquipamiento[2] = true;
        tieneEquipamiento[3] = false;

        iconoMenu.onClick.AddListener(VisionMenu);
        iconoSalir.onClick.AddListener(GuardarSalir);
        iconoStats.onClick.AddListener(VisionStats);
        iconoVolver.onClick.AddListener(VolverStats);
        iconoInventario.onClick.AddListener(VisionInventario);
        botonObjetos.onClick.AddListener((delegate{CambiarInventario("O");}));
        botonEquipamiento.onClick.AddListener((delegate{CambiarInventario("E");}));
        
        CambiarInventario("O");

        botonesInventario[0].onClick.AddListener((delegate{MostrarInventario(imagenesIcono[0],botonesInventario[0],descripcionTextos[0],cantidadObjetosText[0]);}));
        botonesInventario[1].onClick.AddListener((delegate{MostrarInventario(imagenesIcono[1],botonesInventario[1],descripcionTextos[1],cantidadObjetosText[1]);}));
        botonesInventario[2].onClick.AddListener((delegate{MostrarInventario(imagenesIcono[2],botonesInventario[2],descripcionTextos[2],cantidadObjetosText[2]);}));
        botonesInventario[3].onClick.AddListener((delegate{MostrarInventario(imagenesIcono[3],botonesInventario[3],descripcionTextos[3],cantidadObjetosText[3]);}));
        botonesInventario[4].onClick.AddListener((delegate{MostrarInventario(imagenesIcono[4],botonesInventario[4],descripcionTextos[4],cantidadObjetosText[4]);}));
        botonesInventario[5].onClick.AddListener((delegate{MostrarInventario(imagenesIcono[5],botonesInventario[5],descripcionTextos[5],cantidadObjetosText[5]);}));
        botonesInventario[6].onClick.AddListener((delegate{MostrarInventario(imagenesIcono[6],botonesInventario[6],descripcionTextos[6],cantidadObjetosText[6]);}));
        botonesInventario[7].onClick.AddListener((delegate{MostrarInventario(imagenesIcono[7],botonesInventario[7],descripcionTextos[7],cantidadObjetosText[7]);}));
        botonesInventario[8].onClick.AddListener((delegate{MostrarInventario(imagenesIcono[8],botonesInventario[8],descripcionTextos[8],cantidadObjetosText[8]);}));
        botonesInventario[9].onClick.AddListener((delegate{MostrarInventario(imagenesIcono[9],botonesInventario[9],descripcionTextos[9],cantidadObjetosText[9]);}));
        botonesInventario[10].onClick.AddListener((delegate{MostrarInventario(imagenesIcono[10],botonesInventario[10],descripcionTextos[10],cantidadObjetosText[10]);}));
        botonesInventario[11].onClick.AddListener((delegate{MostrarInventario(imagenesIcono[11],botonesInventario[11],descripcionTextos[11],cantidadObjetosText[11]);}));

        botonUsar.onClick.AddListener((delegate{UsarObjeto();}));

    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){

            if(isShowingAlgo){

                menu.SetActive(false);
                inventario.SetActive(false);
                stats.SetActive(false);
                isShowingAlgo = false;
                interfaz.SetActive(true);
                

            }else{

                isShowingAlgo = true;
                menu.SetActive(true);

            }
        }
    }

    public void UsarObjeto(){
        
        if(menuActual == "O"){
            if(nombreObjetoTexto == "Seta roja"){
                if(personajePrincipal.vidaActual != personajePrincipal.vidaTotal){
                    if(cantidadObjetos[0]!=0){
                        cantidadObjetos[0]-=1;
                        personajePrincipal.curarVida(10);
                    }else{
                        imagenInventario.color = new Color(0,0,0,0);
                    }
                }   
            }
            if(nombreObjetoTexto == "Pocion exp pequeña"){
                if(cantidadObjetos[1]!=0){
                    personajePrincipal.subirExp(100d);
                    cantidadObjetos[1]-=1;
                }else{
                    textoDescripcion.text = "";
                    textoObjeto.text = "";
                    botonUsar.GetComponentsInChildren<Text>()[0].text = "";
                }
            }
            CambiarInventario("O");
        }

    }

    public void MostrarInventario(Image imagenMostrar, Button boton, Text texto, Text cantidadTexto){

        imagenInventario.color = new Color(255,255,255,255);

        if(menuActual == "O"){

            imagenInventario.sprite = Sprite.Create((Texture2D)imagenMostrar.sprite.texture,new Rect(0,0,imagenMostrar.sprite.texture.width,imagenMostrar.sprite.texture.height),
                                                new Vector2(imagenMostrar.sprite.texture.width/2, imagenMostrar.sprite.texture.height/2));
        
            textoDescripcion.text = texto.text ;
            textoObjeto.text = boton.GetComponentsInChildren<Text>()[0].text;
            botonUsar.GetComponentsInChildren<Text>()[0].text = "Usar";

        }

        if(menuActual == "E"){

            imagenInventario.sprite = Sprite.Create((Texture2D)imagenMostrar.sprite.texture,new Rect(0,0,imagenMostrar.sprite.texture.width,imagenMostrar.sprite.texture.height),
                                                new Vector2(imagenMostrar.sprite.texture.width/2, imagenMostrar.sprite.texture.height/2));
        
            textoDescripcion.text = texto.text ;
            textoObjeto.text = boton.GetComponentsInChildren<Text>()[0].text;
            botonUsar.GetComponentsInChildren<Text>()[0].text = "Equipar";
        }
        
        nombreObjetoTexto = textoObjeto.text;
        
        // objetoSeleccionado.setSprite(imagenInventario.sprite);
        // objetoSeleccionado.setDescripcion(textoDescripcion.text);
        // objetoSeleccionado.setNombre(textoObjeto.text);
    }

    public void CambiarInventario(string menu){
            

        if(menu == "O"){

            int contador = 0;
            menuActual = "O";

            for(int i = 0; i<12 && i<nombresObjetos.Length; i++){
                
                if(cantidadObjetos[i]>0){

                    botonesInventario[contador].GetComponentsInChildren<Text>()[0].text = nombresObjetos[i];
                    imagenesIcono[contador].sprite = Sprite.Create((Texture2D)imagenesObjetos[i],new Rect(0,0,imagenesObjetos[i].width,imagenesObjetos[i].height),
                                                new Vector2(imagenesObjetos[i].width/2, imagenesObjetos[i].height/2));
                    imagenesIcono[contador].color =  new Color(255,255,255,255);
                    cantidadInventario[contador].text = "x"+cantidadObjetos[i];
                    descripcionTextos[contador].text = descripcionObjetos[i];
                    contador++;
                    
                }
            }

            for(int i = contador; i<12; i++){

                botonesInventario[i].GetComponentsInChildren<Text>()[0].text = "";
                imagenesIcono[i].color =  new Color(0,0,0,0);
                cantidadInventario[contador].text = "";

            }

            var color = botonUsar.targetGraphic.color;
            color.a = 120;
            botonUsar.targetGraphic.color = color;  

        }

        if(menu == "E"){
        
            int contador = 0;
            menuActual = "E";

            for(int i = 0; i<12 && i<nombresEquipamiento.Length; i++){
                
                if(tieneEquipamiento[i] == true){

                    botonesInventario[contador].GetComponentsInChildren<Text>()[0].text = nombresEquipamiento[i];
                    imagenesIcono[contador].sprite = Sprite.Create((Texture2D)imagenesEquipamiento[i],new Rect(0,0,imagenesEquipamiento[i].width,imagenesEquipamiento[i].height),
                                                new Vector2(imagenesEquipamiento[i].width/2, imagenesEquipamiento[i].height/2));
                    imagenesIcono[contador].color =  new Color(255,255,255,255);
                    descripcionTextos[contador].text = descripcionEquipamiento[i];

                    contador++;
               
                }
                cantidadInventario[i].text = "";
            }

            for(int i = contador; i<12; i++){

            botonesInventario[i].GetComponentsInChildren<Text>()[0].text = "";
            imagenesIcono[i].color =  new Color(0,0,0,0);

            }

            var color = botonUsar.targetGraphic.color;
            color.a = 120;
            botonUsar.targetGraphic.color = color;  


        }
    }

    void GuardarSalir(){

        personajePrincipal.controladorDatos.guardarDatos();
        SceneManager.LoadScene("Pantalla de inicio");

    }

    void VisionMenu() {
        if(!isShowingAlgo){
            isShowingAlgo = true;
            menu.SetActive(true);
        }
    }
    
    void VisionStats(){
         if(isShowingAlgo){
            menu.SetActive(false);
            interfaz.SetActive(false);
            stats.SetActive(true);
        }
    }

    void VolverStats(){
         if(isShowingAlgo){
            stats.SetActive(false);
            menu.SetActive(true);
            interfaz.SetActive(true);
        }
    }

    void VisionInventario(){
         if(isShowingAlgo){
            menu.SetActive(false);
            inventario.SetActive(true);
        }
    }
}

