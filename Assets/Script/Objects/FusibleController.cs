using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FusibleController : XRSocketInteractor
{

    public LeverController leverScript;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.CompareTag("Fusible"))
        {
            leverScript.changeFusible();
        }
    }


    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        if (args.interactableObject.transform.CompareTag("Fusible"))
        {
            leverScript.changeFusible();
        }
    }
}
