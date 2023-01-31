using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MorseController : MonoBehaviour
{
    private XRGrabInteractable grabScript;
    private Rigidbody rb;

    private void Start()
    {
        grabScript = GetComponent<XRGrabInteractable>();

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (grabScript.isSelected)
        {
            rb.constraints = RigidbodyConstraints.None;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
    }
}
