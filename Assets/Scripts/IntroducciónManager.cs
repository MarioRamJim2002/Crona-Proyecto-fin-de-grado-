using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public static class FadeAudioSource {
    public static IEnumerator StartFade(AudioSource audioSource, float duracion, float volumen)
    {
        float tiempo = 0;
        float comienzo = audioSource.volume;
        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(comienzo, volumen, tiempo / duracion);
            yield return null;
        }
        yield break;
    }
}

public class IntroducciónManager : MonoBehaviour
{

    public AudioSource musica;

    public Image borde;
    public Image cuadradoDeTexto;

    public Sprite imagen1;
    public Sprite imagen2;
    public Sprite imagen3;
    public Sprite imagen4;
    public Sprite imagen5;
    public Sprite imagen6;
    public Sprite imagen7;
    public Sprite imagen8;

    public Sprite borde1;
    public Sprite cuadradoDeTexto1;

    public string texto1;
    public string texto2;
    public string texto3;
    public string texto4;
    public string texto5;
    public string texto6;
    public string texto7;
    public string texto8;

    public Image imagen;
    public Text texto;
    public Text textoSkip; 

    public float tiempoTransición1;
    public float tiempoTransición2;
    public float tiempoTransición3;
    public float tiempoTransición4;
    public float tiempoTransición5;
    public float tiempoTransición6;
    public float tiempoTransición7;

    private float velocidadTexto = 0.075f; 

    IEnumerator skip(){

        bool skipped = false; 

        if(Input.anyKey){

            textoSkip.text = "Pulsa ESPACIO para saltar la introducción";

            if(Input.GetKeyDown("space")){

                skipped = true;

            }
        }
        
        yield return new WaitForSeconds(1.5f);

        if(skipped==true){

            SceneManager.LoadScene("Escena Principal");

        }

    }

    IEnumerator introducción(){

        cuadradoDeTexto.sprite = cuadradoDeTexto1;
        borde.sprite = borde1;

        imagen.CrossFadeAlpha(0,0f,true);
        borde.CrossFadeAlpha(0,0f,true);
        cuadradoDeTexto.CrossFadeAlpha(0,0f,true);

        imagen.CrossFadeAlpha(1,3f,true);
        cuadradoDeTexto.CrossFadeAlpha(1,3f,true);
        borde.CrossFadeAlpha(1,3f,true);

        yield return new WaitForSeconds(1.5f);

       foreach(char caracter in texto1){

            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(velocidadTexto);

        }

        yield return new WaitForSeconds(tiempoTransición1-1f);
        imagen.CrossFadeAlpha(0,1f,true);
        yield return new WaitForSeconds(1f);
        imagen.CrossFadeAlpha(1,1f,true);

        imagen.sprite = imagen2;

        texto.text = "";

       foreach(char caracter in texto2){

            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(velocidadTexto);

        }

        yield return new WaitForSeconds(tiempoTransición2-1f);
        imagen.CrossFadeAlpha(0,1f,true);
        yield return new WaitForSeconds(1f);
        imagen.CrossFadeAlpha(1,1f,true);

        imagen.sprite = imagen3;

        texto.text = "";

       foreach(char caracter in texto3){

            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(velocidadTexto);

        }

        yield return new WaitForSeconds(tiempoTransición3-1f);
        imagen.CrossFadeAlpha(0,1f,true);
        yield return new WaitForSeconds(1f);
        imagen.CrossFadeAlpha(1,1f,true);

        imagen.sprite = imagen4;

        texto.text = "";

       foreach(char caracter in texto4){

            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(velocidadTexto);

        }

        yield return new WaitForSeconds(tiempoTransición4-1f);
        imagen.CrossFadeAlpha(0,1f,true);
        yield return new WaitForSeconds(1f);
        imagen.CrossFadeAlpha(1,1f,true);

        imagen.sprite = imagen5;

        texto.text = "";

       foreach(char caracter in texto5){

            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(velocidadTexto);

        }

        yield return new WaitForSeconds(tiempoTransición5-1f);
        imagen.CrossFadeAlpha(0,1f,true);
        yield return new WaitForSeconds(1f);
        imagen.CrossFadeAlpha(1,1f,true);

        imagen.sprite = imagen6;

        texto.text = "";

       foreach(char caracter in texto6){

            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(velocidadTexto);

        }

        yield return new WaitForSeconds(tiempoTransición6-1f);
        imagen.CrossFadeAlpha(0,1f,true);
        yield return new WaitForSeconds(1f);
        imagen.CrossFadeAlpha(1,1f,true);

        imagen.sprite = imagen7;

        texto.text = "";

       foreach(char caracter in texto7){

            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(velocidadTexto);

        }

        yield return new WaitForSeconds(tiempoTransición7-1f);
        imagen.CrossFadeAlpha(0,1f,true);
        yield return new WaitForSeconds(1f);
        imagen.CrossFadeAlpha(1,1f,true);

        imagen.sprite = imagen8;

        texto.text = "";

       foreach(char caracter in texto8){

            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(velocidadTexto);

        }

        yield return new WaitForSeconds(2f);
        imagen.CrossFadeAlpha(0,3f,true);
        borde.CrossFadeAlpha(0,3f,true);
        cuadradoDeTexto.CrossFadeAlpha(0,3f,true);
        texto.text = "";
        StartCoroutine(FadeAudioSource.StartFade(musica, 4f, 0f));

        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene("Escena Principal");

    }

    void Start()
    {
        imagen.sprite = imagen1;

        StartCoroutine(this.introducción());
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(this.skip());
    }
}
