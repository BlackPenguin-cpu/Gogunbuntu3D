using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public partial class Player : Singleton<Player>
{
    public bool isPlunger;

    [Header("¶Õ¾î»½ ¿ÀºêÁ§Æ®")]
    [SerializeField] private GameObject plunger;
    private GameObject plunger_obj;

    [Header("¶Õ¾î»½ ½ºÅÝ")]
    [SerializeField] private float plungerSpeed;
    [SerializeField] private float pullPower;

    private void ShootPlunger()
    {
        isPlunger = true;

        //objÀÇ rigid¿¡ drag´Â 0 Áï °ø±âÀúÇ×ÀÌ ¾ø´Ù
        plunger_obj = Instantiate(plunger, transform.position, cam.transform.rotation);
        plunger_obj.GetComponent<Rigidbody>().velocity = cam.transform.forward * plungerSpeed;
    }
    private void PullPlunger()
    {
        if (plunger_obj.GetComponent<Plunger>().isAttach == false) return;
        Vector3 dir = plunger_obj.transform.position - transform.position;
        rb.AddForce(dir * pullPower, ForceMode.Impulse);

        Destroy(plunger_obj);
    }

}
