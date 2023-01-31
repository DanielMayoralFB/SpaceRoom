using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.XR.CoreUtils;


public class PositionController : MonoBehaviour
{
    [SerializeField] InputActionReference moveAction;
    [SerializeField] InputActionReference turnAction;

    private Vector3 zonaCentral;
    public Transform zonaPrimeraPrueba;
    public Transform zonaSegundaPrueba;
    public Transform zonaTerceraPrueba;
    public Transform zonaCuartaPrueba;

    public Transform zonaFinal;

    private RaycastHit hit;

    private XROrigin origin;

    // Start is called before the first frame update
    void Start()
    {
        origin = GetComponent<XROrigin>();
        zonaCentral = transform.position;

        moveAction.action.performed += moveTo;
        turnAction.action.performed += turnTo;
    }

    void moveTo(InputAction.CallbackContext context)
    {

        if (transform.position != zonaCentral && context.ReadValue<Vector2>().y < 0f)
        {
            transform.position = zonaCentral;
        }

        if ((transform.position.x == zonaCentral.x || transform.position.x == zonaFinal.position.x) && context.ReadValue<Vector2>().y > 0f)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {

                if (hit.collider.CompareTag("zonaPrimeraPrueba"))
                {
                    transform.position = zonaPrimeraPrueba.position;
                }
                else if (hit.collider.CompareTag("zonaSegundaPrueba"))
                {
                    Debug.Log(transform.position);
                    transform.position = zonaSegundaPrueba.position;
                    Debug.Log(transform.position);
                }
                else if (hit.collider.CompareTag("zonaTerceraPrueba"))
                {
                    transform.position = zonaTerceraPrueba.position;
                }
                else if (hit.collider.CompareTag("zonaCuartaPrueba"))
                {
                    transform.position = zonaCuartaPrueba.position;
                }
            }
        }
    }

    void turnTo(InputAction.CallbackContext context)
    {
        if(context.ReadValue<Vector2>().x < 0){
            transform.RotateAround(transform.position, Vector3.up, -90);
        }
        if(context.ReadValue<Vector2>().x > 0)
        {
            transform.RotateAround(transform.position, Vector3.up, 90);
        }
    }


    public void goToZonaFinal()
    {
        transform.position = zonaFinal.position;
    }

}
