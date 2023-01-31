using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    private TextMesh texto;

    private string[] listaNumeros;

    private int indice = 0;

    private void Start()
    {
        texto = GetComponentInChildren<TextMesh>();
        if (gameObject.CompareTag("TextoPrimera"))
        {
            listaNumeros = new string[8] { "2", "A", "4", "J", "6", "Q", "9", "K" };
        }else if (gameObject.CompareTag("TextoSegunda")){
            listaNumeros = new string[8] { "9", "Q", "8", "Y", "E", "T", "U", "W" };
        }else if (gameObject.CompareTag("TextoTercera"))
        {
            listaNumeros = new string[3] { "1", "8", "9"};
        }
        else
        {
            listaNumeros = new string[6] { "1", "4", "3","8", "5", "7"};
        }
    }

    public void cambiarTexto()
    {
        indice++;
        if (indice >= listaNumeros.Length)
            indice = 0;
        texto.text = listaNumeros[indice];
    }
}
