using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonController : MonoBehaviour
{

    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float zonaLimite = 0.025f;


    private bool esPresionado;
    private Vector3 posicionInicial;
    private ConfigurableJoint joint;

    public UnityEvent onPressed;


    public TextMesh valor1;
    public TextMesh valor2;
    public TextMesh valor3;
    public TextMesh valor4;

    public CajaController cajaPrueba;


    private void Start()
    {
        posicionInicial = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();

    }

    private void FixedUpdate()
    {
        if(!esPresionado && GetValue() + threshold >= 1)
        {
            Pressed();
        }
        if(esPresionado && GetValue() - threshold <= 0.75)
        {
            esPresionado = false;
        }
    }

    private float GetValue()
    {
        var value = Vector3.Distance(posicionInicial, transform.localPosition) / joint.linearLimit.limit;

        if(Math.Abs(value) < zonaLimite)
        {
            value = 0;
        }

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        esPresionado = true;
        onPressed.Invoke();
    }

    public void comprobarNumeros()
    {
        if (gameObject.CompareTag("ConfirmarPrimera"))
        {
            if (valor1.text.Equals("9") && valor2.text.Equals("4") && valor3.text.Equals("6") && valor4.text.Equals("2"))
            {
                cajaPrueba.completado();
            }
            else
            {
                HapticError();
            }
        }
        else if (gameObject.CompareTag("ConfirmarSegunda"))
        {
            if (valor1.text.Equals("Q") && valor2.text.Equals("U") && valor3.text.Equals("9") && valor4.text.Equals("T"))
            {
                cajaPrueba.completado();
            }
            else
            {
                HapticError();
            }
        }
        else if (gameObject.CompareTag("ConfirmarTercera"))
        {
            if (valor1.text.Equals("1") && valor2.text.Equals("8") && valor3.text.Equals("9"))
            {
                cajaPrueba.completado();
            }
            else
            {
                HapticError();
            }
        }
        else
        {
            if (valor1.text.Equals("1") && valor2.text.Equals("3") && valor3.text.Equals("5") && valor4.text.Equals("7"))
            {
                cajaPrueba.completado();
            }
            else
            {
                HapticError();
            }
        }
    }


    void HapticError()
    {
        GameObject.FindGameObjectWithTag("LeftHand").GetComponent<XRDirectInteractor>().SendHapticImpulse(0.8f, 0.4f);
        GameObject.FindGameObjectWithTag("RightHand").GetComponent<XRDirectInteractor>().SendHapticImpulse(0.8f, 0.4f);
    }
}
