using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_lance : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    private Vector2 movement;
    private Rigidbody2D rb;
    [SerializeField] private float currenSpeed;
    //private Controllers playerInput;


    private void Awake()
    {
        GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        //playerInput = new Controllers();
    }

    void Start()
    {
        
    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("homme_feu"))
        {
            spriteRenderer.color = Color.green;
        }

        if (col.gameObject.CompareTag("homme"))
        {
            spriteRenderer.color = Color.magenta;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        spriteRenderer.color = Color.red;
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
        rb.velocity = movement * currenSpeed;
    }
    
    /*
    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
    */
}
