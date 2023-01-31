using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Fusible : MonoBehaviour
{
    private XRGrabInteractable grabScript;

    private XRDirectInteractor lInteractor;
    private XRDirectInteractor rInteractor;

    private PositionController positionScript;

    private void Start()
    {
        grabScript = GetComponent<XRGrabInteractable>();

        positionScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PositionController>();
        lInteractor = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<XRDirectInteractor>();
        rInteractor = GameObject.FindGameObjectWithTag("RightHand").GetComponent<XRDirectInteractor>();
    }

    private void Update()
    {
        if (grabScript.isSelected)
        {
            if (lInteractor.IsSelecting(grabScript))
            {
                positionScript.goToZonaFinal();
            }

            if (rInteractor.IsSelecting(grabScript))
            {
                positionScript.goToZonaFinal();
            }
        }
    }
}
