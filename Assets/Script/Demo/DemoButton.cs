using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class DemoButton : MonoBehaviour
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


    public FinalDemo finalScript;

    private void Start()
    {
        posicionInicial = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();

    }

    private void FixedUpdate()
    {
        if (!esPresionado && GetValue() + threshold >= 1)
        {
            Pressed();
        }
        if (esPresionado && GetValue() - threshold <= 0.75)
        {
            esPresionado = false;
        }
    }

    private float GetValue()
    {
        var value = Vector3.Distance(posicionInicial, transform.localPosition) / joint.linearLimit.limit;

        if (Math.Abs(value) < zonaLimite)
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
        if (gameObject.CompareTag("DemoPrimera"))
        {
            if (valor1.text.Equals("3") && valor2.text.Equals("5") && valor3.text.Equals("8") && valor4.text.Equals("1"))
            {
                finalScript.completarPrimera();
            }
            else
            {
                HapticError();
            }
        }
        else if (gameObject.CompareTag("DemoSegunda"))
        {
            if (valor1.text.Equals("4") && valor2.text.Equals("6") && valor3.text.Equals("1") && valor4.text.Equals("3"))
            {
                finalScript.completarSegunda();
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
