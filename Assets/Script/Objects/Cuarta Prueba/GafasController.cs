using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class GafasController : MonoBehaviour
{


    private XRGrabInteractable grabScript;

    private Rigidbody rb;

    public GameObject textoCristal;

    private Transform attachTransform;

    private GameObject[] textos = new GameObject[8];

    private Vector3 escala;

    // Start is called before the first frame update
    void Start()
    {

        grabScript = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        attachTransform = GameObject.FindGameObjectWithTag("AttachCristal").GetComponent<Transform>();
        textos = GameObject.FindGameObjectsWithTag("TextoFiltro");

        escala = transform.localScale;
    }


    private void Update()
    {
        if (grabScript.isSelected)
        {
            textoCristal.SetActive(true);
            rb.constraints = RigidbodyConstraints.None;
        }
        else
        {
            textoCristal.SetActive(false);
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }

        if(transform.position == attachTransform.position)
        {
            transform.localScale = new Vector3(5,5,transform.localScale.z);
            for (int i = 0; i < textos.Length; i++)
            {
                textos[i].GetComponent<MeshRenderer>().enabled = true;
            }
        }
        else
        {
            transform.localScale = escala;
            for (int i = 0; i < textos.Length; i++)
            {
                textos[i].GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

}
