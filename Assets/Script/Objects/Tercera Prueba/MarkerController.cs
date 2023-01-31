using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MarkerController : MonoBehaviour
{

    [SerializeField] private Transform tip;
    [SerializeField] private int penSize = 5;

    private Renderer rendererR;
    private XRGrabInteractable grabScript;
    private Rigidbody rb;

    private Color[] colorMarker;
    private float tipHeight;

    private RaycastHit touch;
    private ClockController reloj;
    private Vector2 touchPosition;
    private Vector2 lastTouchPosition;
    private Quaternion lastTouchRotation;
    private bool touchedLastFrame;

    private void Start()
    {
        rendererR = tip.GetComponent<Renderer>();
        grabScript = GetComponentInParent<XRGrabInteractable>();
        rb = GetComponentInParent<Rigidbody>();

        colorMarker = Enumerable.Repeat(rendererR.material.color,penSize*penSize).ToArray();
        tipHeight = tip.localScale.y/2;
    }

    private void Update()
    {
        Draw();

        if (!grabScript.isSelected)
        {
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    private void Draw()
    {
        if(Physics.Raycast(tip.position, transform.up, out touch, 0.03f))
        {
            if (touch.transform.CompareTag("Reloj"))
            {
                if(reloj == null)
                {
                    reloj = touch.transform.GetComponent<ClockController>();
                }

                touchPosition = new Vector2(touch.textureCoord.x, touch.textureCoord.y);

                var x = (int)(touchPosition.x * reloj.textureSize.x - (penSize / 2));
                var y = (int)(touchPosition.y * reloj.textureSize.y - (penSize / 2));

                if (y < 0 || y > reloj.textureSize.y || x < 0 || x > reloj.textureSize.x) return;

                if (touchedLastFrame)
                {
                    reloj.texture.SetPixels(x, y, penSize, penSize, colorMarker);

                    for(float i = 0.01f; i < 1.00f; i+=0.03f)
                    {
                        var lerpX = (int)Mathf.Lerp(lastTouchPosition.x, x, i);
                        var lerpY = (int)Mathf.Lerp(lastTouchPosition.y, y, i);
                        reloj.texture.SetPixels(lerpX, lerpY, penSize, penSize, colorMarker);
                    }

                    transform.rotation = lastTouchRotation;

                    reloj.texture.Apply();
                }

                lastTouchPosition = new Vector2(x, y);
                lastTouchRotation = transform.rotation;
                touchedLastFrame = true;
                return;
            }
        }

        reloj = null;
        touchedLastFrame = false;
    }
}
