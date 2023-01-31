using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    public void openDoor()
    {
        animator.SetBool("isOpening", true);
    }
}
