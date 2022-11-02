using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public partial class Player : Singleton<Player>
{
    private bool isPlunger;

    private GameObject plunger;
    private GameObject plunger_obj;

    [SerializeField] private float plungerSpeed;

    private void ShootPlunger()
    {
        isPlunger = true;

        //obj의 rigid에 drag는 0 즉 공기저항이 없다
        plunger_obj = Instantiate(plunger, transform.position, Quaternion.Euler(cam.transform.forward));
        plunger_obj.GetComponent<Rigidbody>().velocity = plunger_obj.transform.forward * plungerSpeed;
    }
    private void PullPlunger()
    {
        Destroy(plunger_obj);

    }

}
