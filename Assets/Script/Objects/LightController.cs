using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private Light lightV;

    void Start()
    {
        lightV = GetComponent<Light>();

        lightV.intensity = 0;
    }

    public void changeLight(float valor)
    {
        lightV.intensity = valor;
    }

    public float getIntensity()
    {
        return lightV.intensity;
    }
}
