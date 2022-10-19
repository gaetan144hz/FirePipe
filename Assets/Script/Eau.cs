using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Eau : MonoBehaviour
{
    public Homme homme;
    [SerializeField] float timeToDestroy;

    private void Start()
    {
        Destroy(this.gameObject,timeToDestroy);
    }

    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("homme_feu"))
        {
            homme = col.gameObject.GetComponent<Homme>();
            homme.addTime(5);
            Destroy(this.gameObject,0.3f);
        }
    }
}