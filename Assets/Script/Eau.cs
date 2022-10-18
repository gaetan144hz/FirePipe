using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Eau : MonoBehaviour
{
    [SerializeField] float timeToDestroy;

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("homme_feu"))
        {
            Destroy(this.gameObject,timeToDestroy);
        }
    }
}