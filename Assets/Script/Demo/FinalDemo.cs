using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDemo : MonoBehaviour
{

    private bool primeraCompletada;
    private bool segundaCompletada;
    // Start is called before the first frame update
    void Start()
    {
        primeraCompletada = false;
        segundaCompletada = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(primeraCompletada && segundaCompletada)
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
    }

    public void completarPrimera()
    {
        primeraCompletada = true;
    }

    public void completarSegunda()
    {
        segundaCompletada = true;
    }
}
