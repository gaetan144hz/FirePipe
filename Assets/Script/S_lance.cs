using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_lance : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    
    [SerializeField] private float currenSpeed;
    private Vector2 movement;
    private Rigidbody2D rb;
    
    private Controllers playerInput;
    
    public GameObject eau;
    public Transform firePoint;

    private void Awake()
    {
        GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        playerInput = new Controllers();
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

    public void Move(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Vector2 movement = playerInput.croasshair.Move.ReadValue<Vector2>();
            //movement = value.Get<Vector2>();
            rb.velocity = movement * currenSpeed;
        }
    }

    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Instantiate(eau, firePoint.position, firePoint.rotation);
        }
    }
    
    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
    
}
