using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Title : MonoBehaviour
{
    Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        transform.position += Vector3.up * Mathf.Cos(Time.time * Time.deltaTime * 5);

        if (Input.anyKeyDown) AnyInput();
    }
    public void AnyInput()
    {
        image.DOFade(0, 1).OnComplete(() => gameObject.SetActive(false));
    }
}
