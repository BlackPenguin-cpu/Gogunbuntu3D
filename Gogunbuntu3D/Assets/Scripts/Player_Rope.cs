using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public partial class Player : Singleton<Player>
{
    public bool isPlunger;

    [Header("�վ ������Ʈ")]
    [SerializeField] private GameObject plunger;
    private GameObject plunger_obj;

    [Header("�վ ����")]
    [SerializeField] private float plungerSpeed;
    [SerializeField] private float pullPower;

    private void ShootPlunger()
    {
        isPlunger = true;
        SoundManager.instance.PlaySoundClip("Rope2", SoundType.SFX, 2);

        //obj�� rigid�� drag�� 0 �� ���������� ����
        plunger_obj = Instantiate(plunger, transform.position, cam.transform.rotation);
        plunger_obj.GetComponent<Rigidbody>().velocity = cam.transform.forward * plungerSpeed;
    }
    private void PullPlunger()
    {
        if (plunger_obj.GetComponent<Plunger>().isAttach == false) return;
        Vector3 dir = Vector3.Normalize(plunger_obj.transform.position - transform.position);

        rb.AddForce(new Vector3(dir.x, dir.y * 1.5f, dir.z) * pullPower, ForceMode.Impulse);

        SoundManager.instance.PlaySoundClip("Rope", SoundType.SFX);


        Destroy(plunger_obj);
    }

}
