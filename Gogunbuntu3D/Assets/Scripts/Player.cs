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
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }
    private void FixedUpdate()
    {
        
    }
}
