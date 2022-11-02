using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(Rigidbody))]
public partial class Player : Singleton<Player>
{
    [HideInInspector]
    public Rigidbody rb;
    private Camera cam;

    public float m_Speed = 100;
    public float MaxSpeed = 15;
    public float jumpPower = 500;
    float h;
    float v;
    [SerializeField]
    GameObject CamArm;
    float mouseX = 0;
    float mouseY = 0;
    public float MouseSense = 3;
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
    	MouseInput();
        playerMove();
        MouseRotate();
        playerJump();
    }
    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootPlunger();
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (isPlunger) PullPlunger();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (plunger_obj != null) Destroy(plunger_obj);
        }
    }
    void playerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0, jumpPower, 0);
        }
    }
    void playerMove()
    {
        if (rb.velocity.x > MaxSpeed ||
                    rb.velocity.x < -MaxSpeed)
        {
            h = 0;
        }
        else
        {
            h = Input.GetAxisRaw("Horizontal");
        }
        if (rb.velocity.z > MaxSpeed && v > 0 ||
           rb.velocity.z < -MaxSpeed && v < 0)
        {
            v = 0;
        }
        else
        {
            v = Input.GetAxisRaw("Vertical");
        }
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
