using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoButton : MonoBehaviour
{
    private TextMesh texto;

    private string[] listaNumeros;

    private int indice = 0;

    private void Start()
    {
        texto = GetComponentInChildren<TextMesh>();
        if (gameObject.CompareTag("TextoDemo1"))
        {
            listaNumeros = new string[6] { "3", "4", "5", "8", "6", "1" };
        }
        else if (gameObject.CompareTag("TextoDemo2"))
        {
            listaNumeros = new string[6] { "4", "6", "9", "1", "5", "3"};
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
