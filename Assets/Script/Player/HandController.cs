using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.XR.CoreUtils;


public class HandController : MonoBehaviour
{

    [SerializeField] InputActionReference actionTrigger;
    [SerializeField] InputActionReference gripAnimation;
    [SerializeField] InputActionReference triggerAnimation;
    [SerializeField] InputActionReference menuAction;
    

    private SphereCollider sphereCollider;
    private Animator animator;

    private bool activateMenu = false;


    void Start()
    {
        if(gameObject.CompareTag("RightHand") || gameObject.CompareTag("LeftHand"))
        {
            sphereCollider = GetComponent<SphereCollider>();
            animator = GetComponentInChildren<Animator>();
        }


        //actionTrigger.action.performed += changeTrigger;
        sphereCollider.isTrigger = true;

        gripAnimation.action.performed += animationGrip;
        triggerAnimation.action.performed += animationTrigger;

    }

    private void FixedUpdate()
    {
        if (actionTrigger.action.IsPressed())
        {
            sphereCollider.isTrigger = false;
        }
        else
        {
            sphereCollider.isTrigger = true;
        }
    }

    void changeTrigger(InputAction.CallbackContext context)
    {
        if(context.ReadValue<float>() > 0.1f)
        {
            sphereCollider.isTrigger = false;
        }
        else
        {
            sphereCollider.isTrigger = true;
        }
    }

    void animationGrip(InputAction.CallbackContext context)
    {
        animator.SetFloat("Grip", context.ReadValue<float>());
    }

    void animationTrigger(InputAction.CallbackContext context)
    {
        animator.SetFloat("Trigger", context.ReadValue<float>());
    }
}
