using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpringJoint))]
[RequireComponent(typeof(LineRenderer))]
public class Plunger : MonoBehaviour
{
    public bool isAttach;

    [SerializeField] private float maxDistance;
    private Rigidbody rb;
    private SpringJoint springJoint;
    private LineRenderer lineRenderer;
    private Player player;

    private float duration = 100;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        springJoint = GetComponent<SpringJoint>();
        lineRenderer = GetComponent<LineRenderer>();

        player = Player.Instance;
    }
    private void Update()
    {
        lineRenderer.SetPosition(1, player.transform.position);
        lineRenderer.SetPosition(0, transform.position);

        duration -= Time.deltaTime;
        if (duration < 0) Destroy(gameObject);

        if (Vector3.Distance(player.transform.position, transform.position) >= maxDistance)
        {
            player.isPlunger = false;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Wall"))
        {
            SoundManager.instance.PlaySoundClip("Plunger", SoundType.SFX);

            isAttach = true;
            rb.isKinematic = true;
            springJoint.connectedBody = player.rb;
        }
    }
}
