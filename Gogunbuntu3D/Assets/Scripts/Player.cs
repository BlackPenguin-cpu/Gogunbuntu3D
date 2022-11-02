using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(Rigidbody))]
public partial class Player : Singleton<Player>
{
    private Camera cam;
    public Rigidbody rb;

    public float m_Speed;
    public void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
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
    private void FixedUpdate()
    {

    }
}
