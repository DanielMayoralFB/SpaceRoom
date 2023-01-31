using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class LeverController : MonoBehaviour
{

    private LightController lightScript;

    private bool hasFusible;

    private void Start()
    {

        hasFusible = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("LeverSphere"))
        {

            if (hasFusible)
            {
                SceneManager.LoadScene("FinalScene");
            }
            else
            {
                GameObject.FindGameObjectWithTag("LeftHand").GetComponent<XRDirectInteractor>().SendHapticImpulse(0.8f, 0.4f);
                GameObject.FindGameObjectWithTag("RightHand").GetComponent<XRDirectInteractor>().SendHapticImpulse(0.8f, 0.4f);
            }
        }
    }

    public void changeFusible()
    {
        hasFusible = !hasFusible;
    }


}
