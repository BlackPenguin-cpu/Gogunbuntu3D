using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private Rigidbody rb;

    public float m_Speed;
    float h;
    float v;
    [SerializeField]
    GameObject CamArm;
    float mouseX = 0;
    float mouseY = 0;
    public float MouseSense;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        playerMove();
        MouseRotate();
    }
    void playerMove()
    {
        if (rb.velocity.x > m_Speed && h > 0 ||
                    rb.velocity.x < -m_Speed && h < 0)
        {
            h = 0;
        }
        else
        {
            h = Input.GetAxisRaw("Horizontal");
        }
        if (rb.velocity.z > m_Speed && v > 0 ||
           rb.velocity.z < -m_Speed && v < 0)
        {
            v = 0;
        }
        else
        {
            v = Input.GetAxisRaw("Vertical");
        }
        Debug.Log($"{rb.velocity},{transform.forward}");
    }
    void MouseRotate()
    {
        mouseX += Input.GetAxis("Mouse X") * MouseSense;
        mouseY -= Input.GetAxis("Mouse Y") * (MouseSense * 0.8f);
        mouseY = Mathf.Clamp(mouseY, -55, 55);
        transform.eulerAngles = new Vector3(0, mouseX, 0);
        CamArm.transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
    }
    private void FixedUpdate()
    {
        Vector3 forwardPos = transform.forward;

        rb.AddRelativeForce(new Vector3(h, 0, v) * m_Speed);
    }
}
