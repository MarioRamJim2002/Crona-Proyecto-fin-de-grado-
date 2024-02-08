using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KuakStarStudio : MonoBehaviour
{

    public Image fondo;
    public Image logoImg;

    void Start()
    {
        StartCoroutine(this.logo());
    }

    void Update()
    {
        
    }

    IEnumerator logo(){

        logoImg.CrossFadeAlpha(0,0f,true);
        fondo.CrossFadeAlpha(1,1f,true);
        logoImg.CrossFadeAlpha(1,1f,true);
        yield return new WaitForSeconds(3.5f);
        logoImg.CrossFadeAlpha(0,1f,true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Pantalla de inicio");

    }
}


