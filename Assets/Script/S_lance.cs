using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class S_lance : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    
    [SerializeField] private float currenSpeed;
    public bool canShoot;
    private Rigidbody2D rb;
    
    private Controllers playerInput;
    
    public GameObject eau;
    public Transform firePoint;

    public Slider slider;

    private void Awake()
    {
        GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        playerInput = new Controllers();
    }

    void Start()
    {
        canShoot = true;
    }
    
    void Update()
    {
        if (slider.value <= 0)
        {
            canShoot = false;
        }
        else if (slider.value >= 0)
        {
            canShoot = true;
        }
    }

    #region Trigger

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

    #endregion
    

    public void Movement(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Vector2 moveInput = playerInput.croasshair.Move.ReadValue<Vector2>();
            rb.velocity = moveInput * currenSpeed;
        }
    }

    public void Refill(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            slider.value += 1;
        }
    }

    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (ctx.started && canShoot == true)
        {
            Instantiate(eau, firePoint.position, firePoint.rotation);
            slider.value -= 1;
        }

        if (ctx.canceled)
        {
            return;
        }
    }

    public void Mousse(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Debug.Log("Mousse");
        }
    }

    #region PlayerInput

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    #endregion
}
