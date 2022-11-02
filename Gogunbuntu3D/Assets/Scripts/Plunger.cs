using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpringJoint))]
[RequireComponent(typeof(LineRenderer))]
public class Plunger : MonoBehaviour
{
    private Rigidbody rb;
    private SpringJoint springJoint;
    private LineRenderer lineRenderer;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        springJoint = GetComponent<SpringJoint>();
        rb = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        lineRenderer.SetPosition(1, Player.Instance.transform.position);
        lineRenderer.SetPosition(0, transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Wall"))
        {
            rb.isKinematic = true;
            springJoint.connectedBody = Player.Instance.rb;
        }
    }
}
