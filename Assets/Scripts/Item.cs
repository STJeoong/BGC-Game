using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    void Start()
    {
        GlobalLight.OnFadeIn += OnFadeIn;
    }

    void OnFadeIn()
    {
        Debug.Log($"{transform.name} ��¦");
    }

    private void OnDisable()
    {
        GlobalLight.OnFadeIn -= OnFadeIn;
    }
}
