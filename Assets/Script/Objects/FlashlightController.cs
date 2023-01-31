using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class FlashlightController : MonoBehaviour
{
    private XRGrabInteractable grabScript;
    private InputAction lActivateFlash;
    private InputAction rActivateFlash;
    private XRDirectInteractor lInteractor;
    private XRDirectInteractor rInteractor;
    [Space] [SerializeField] private InputActionAsset actionsAsset;

    private Light lightControl;
    private Rigidbody rb;

    private void Start()
    {
        grabScript = GetComponent<XRGrabInteractable>();
        lActivateFlash = actionsAsset.FindAction("XRI LeftHand Interaction/FlashActivate");
        rActivateFlash = actionsAsset.FindAction("XRI RightHand Interaction/FlashActivate");
        lightControl = GetComponentInChildren<Light>();

        lInteractor = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<XRDirectInteractor>();
        rInteractor = GameObject.FindGameObjectWithTag("RightHand").GetComponent<XRDirectInteractor>();


        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (grabScript.isSelected)
        {
            rb.constraints = RigidbodyConstraints.None;
            if (lInteractor.IsSelecting(grabScript))
            {
                if (lActivateFlash.triggered)
                {
                    
                    if(lightControl.intensity <= 0)
                    {
                        lightControl.intensity = 0.75f;
                    }
                    else
                    {
                        lightControl.intensity = 0;
                    }
                }
            }

            if (rInteractor.IsSelecting(grabScript))
            {
                if (rActivateFlash.triggered)
                {
                    if (lightControl.intensity <= 0)
                    {
                        lightControl.intensity = 0.75f;
                    }
                    else
                    {
                        lightControl.intensity = 0;
                    }
                }
            }
            

            gameObject.transform.rotation.Set(0, 90, 0, 0);
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
    }
}
