using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class SC_Water : MonoBehaviour
{
    public SC_Homme homme;
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
            homme = col.gameObject.GetComponent<SC_Homme>();
            homme.addTime(5);
            Destroy(this.gameObject,0.3f);
        }
    }
}