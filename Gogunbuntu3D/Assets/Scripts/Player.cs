using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

[RequireComponent(typeof(Rigidbody))]
public partial class Player : Singleton<Player>
{
    [HideInInspector]
    public Rigidbody rb;
    public float m_Speed = 100, jumpPower = 500, gravityScale = 98, MaxSpeed = 15;
    public float MouseSense = 3;

    private int jumpCount = 2;
    [SerializeField]
    private GameObject CamArm;

    private Camera cam;

    private float h, v;
    private float mouseX, mouseY;

    [SerializeField] private float rayDistance;
    void Start()
    {
        if (instance == null)
            instance = this;
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        SoundManager.instance.PlaySoundClip("GogunbuntuBGM", SoundType.BGM);
    }

    void Update()
    {
        MouseInput();
        playerMove();
        MouseRotate();
        playerJump();
        GravityAccept();

    }
    private void GravityAccept()
    {
        rb.AddForce(Vector3.down * gravityScale * Time.deltaTime, ForceMode.Impulse);
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
        Debug.DrawRay(transform.position, Vector3.down * rayDistance, Color.red);
        if (Physics.Raycast(transform.position, Vector3.down,
        rayDistance, LayerMask.GetMask("Ground")) && rb.velocity.y < 0)
        {
            jumpCount = 2;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount != 0)
            {
                rb.AddForce(0, jumpPower, 0, ForceMode.Impulse);
                SoundManager.instance.PlaySoundClip("Jump", SoundType.SFX);

                jumpCount--;
            }

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
        Debug.Log(rb.velocity);
    }
    void MouseRotate()
    {
        mouseX += Input.GetAxis("Mouse X") * MouseSense;
        mouseY -= Input.GetAxis("Mouse Y") * (MouseSense * 0.8f);
        mouseY = Mathf.Clamp(mouseY, -75, 75);
        transform.eulerAngles = new Vector3(0, mouseX, 0);
        CamArm.transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
    }
    private void FixedUpdate()
    {
        //Move
        rb.AddRelativeForce(new Vector3(h, 0, v) * m_Speed, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag.Equals("Fire")) Die();
    }
    private void Die()
    {
        SoundManager.instance.PlaySoundClip("DIE", SoundType.SFX , 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
