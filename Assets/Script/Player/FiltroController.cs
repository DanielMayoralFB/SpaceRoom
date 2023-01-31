using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FiltroController : XRSocketInteractor
{
    private GameObject[] textos = new GameObject[8];

    protected override void Awake()
    {
        textos = GameObject.FindGameObjectsWithTag("TextoFiltro");
    }
    protected override void OnSelectEntered(XRBaseInteractable interactable)
    {
        Debug.Log("Aqui estoy");
        if (interactable.CompareTag("CristalFiltro"))
        {
            for (int i = 0; i < textos.Length; i++)
            {
                textos[i].GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
