using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]

public class DatosJuego{

    public int cantidadSetaD;
    public int cantidadExpPequeD;
    public int xD;
    public int yD;

    public int persVidaMaximaD;
    public int persVidaActualD;
    public int persNivelD;
    public int persExpMaximaD;
    public int persExpActualD;
    public int persAtaqueD;
    public int persDefensaD;
    public int persVelocidadD;

    public bool isDestroyedD;

}

public class ControladorDatos : MonoBehaviour
{

    public DatosJuego datosJuego = new DatosJuego();

    public string archivoDeGuardado;

    public static ControladorDatos Instance;

    public int cantidadSeta;
    public int cantidadExpPeque;
    public int x;
    public int y;

    public int persVidaMaxima;
    public int persVidaActual;
    public int persNivel;
    public int persExpMaxima;
    public int persExpActual;
    public int persAtaque;
    public int persDefensa;
    public int persVelocidad;

    public int enemVida;
    public int enemExp;
    public int enemAtaque;
    public int enemDefensa;
    public int enemVelocidad; 
    public int enemNivel;
    public bool isDestroyed;
    
    public bool tieneInfo = false; 
    
    private void Awake(){

        archivoDeGuardado = Application.dataPath+"/datosJuego.json";

        if(ControladorDatos.Instance == null){

            ControladorDatos.Instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else 
        {

            Destroy(gameObject);

        }
    }

    public void cargarDatos(){

                if(File.Exists(archivoDeGuardado)){

            string contenido = File.ReadAllText(archivoDeGuardado);
            datosJuego =  JsonUtility.FromJson<DatosJuego>(contenido);
            
            cantidadSeta = datosJuego.cantidadSetaD;
            cantidadExpPeque = datosJuego.cantidadExpPequeD;
            x = datosJuego.xD;
            y = datosJuego.yD;
            persVidaMaxima = datosJuego.persVidaMaximaD;
            persVidaActual = datosJuego.persVidaActualD;
            persNivel = datosJuego.persNivelD;
            persExpMaxima = datosJuego.persExpMaximaD;
            persExpActual = datosJuego.persExpActualD;
            persAtaque = datosJuego.persAtaqueD;
            persDefensa = datosJuego.persDefensaD; 
            persVelocidad = datosJuego.persVelocidadD;
            isDestroyed = datosJuego.isDestroyedD;
            tieneInfo = true;

        }

    }

    public void guardarDatos(){

        DatosJuego nuevosDatos = new DatosJuego(){

            xD = Instance.x, 
            yD = Instance.y,
            persNivelD = Instance.persNivel,
            persVidaMaximaD = Instance.persVidaMaxima,
            persVidaActualD = Instance.persVidaActual,
            persExpMaximaD = Instance.persExpMaxima,
            persExpActualD = Instance.persExpActual,
            persAtaqueD = Instance.persAtaque,
            persDefensaD = Instance.persDefensa,
            persVelocidadD = Instance.persVelocidad,
            isDestroyedD = Instance.isDestroyed

        };

        string cadenaJSON = JsonUtility.ToJson(nuevosDatos);

        File.WriteAllText(archivoDeGuardado, cadenaJSON);

    }
}
