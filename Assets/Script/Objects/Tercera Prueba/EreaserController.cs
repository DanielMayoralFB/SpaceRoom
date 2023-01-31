using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class EreaserController : MonoBehaviour
{

    [SerializeField] private Transform ereaser;
    [SerializeField] private int penSize = 5;

    private Color[] colors;
    private float erSize;

    private XRGrabInteractable grabScript;
    private Rigidbody rb;

    private RaycastHit touch;
    private ClockController reloj;
    private Vector2 touchPosition;
    private Vector2 lastTouchPosition;
    private Quaternion lastTouchRotation;
    private bool touchedLastFrame;

    private void Start()
    {

        grabScript = GetComponentInParent<XRGrabInteractable>();
        rb = GetComponentInParent<Rigidbody>();


        colors = Enumerable.Repeat(Color.white, penSize * penSize).ToArray();
        erSize = ereaser.localScale.y;
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
        if (Physics.Raycast(ereaser.position, transform.up, out touch, erSize))
        {
            if (touch.transform.CompareTag("Reloj"))
            {
                if (reloj == null)
                {
                    reloj = touch.transform.GetComponent<ClockController>();
                }

                touchPosition = new Vector2(touch.textureCoord.x, touch.textureCoord.y);

                var x = (int)(touchPosition.x * reloj.textureSize.x);
                var y = (int)(touchPosition.y * reloj.textureSize.y);

                if (y < 0 || y > reloj.textureSize.y || x < 0 || x > reloj.textureSize.x) return;

                if (touchedLastFrame)
                {
                    reloj.texture.SetPixels(x, y, penSize, penSize, colors);

                    for (float i = 0.01f; i < 1.00f; i += 0.03f)
                    {
                        var lerpX = (int)Mathf.Lerp(lastTouchPosition.x, x, i);
                        var lerpY = (int)Mathf.Lerp(lastTouchPosition.y, y, i);
                        reloj.texture.SetPixels(lerpX, lerpY, penSize, penSize, colors);
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
