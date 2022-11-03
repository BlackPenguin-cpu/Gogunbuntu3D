using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpinGear : MonoBehaviour
{
    public float SpinSpeed;
    void Start()
    {
        StartCoroutine(Spin());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Spin()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + SpinSpeed, transform.eulerAngles.z);
        yield return new WaitForSeconds(Time.deltaTime);
        StartCoroutine(Spin());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
