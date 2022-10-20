using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SC_Lance : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    public GameObject fxJet;
    
    private Vector2 moveInput;
    [SerializeField] private float currenSpeed;
    public bool fullTanck;
    public float autoFireRate;
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
        fxJet.SetActive(false);
        fullTanck = true;
        canShoot = true;
    }
    
    void Update()
    {
        if (slider.value <= 0)
        {
            fullTanck = false;
        }
        else if (slider.value >= 0)
        {
            fullTanck = true;
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
    

    public void Move(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            moveInput = playerInput.croasshair.Move.ReadValue<Vector2>();
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

    #region Shooting

    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && fullTanck == true)
        {
            fxJet.SetActive(enabled);
            canShoot = true;
            StartCoroutine(autoShoot());
            return;
        }
        else
        {
            fxJet.SetActive(false);
            canShoot = false;
            return;
        }
    }
    
    public IEnumerator autoShoot()
    {
        while (canShoot == true)
        {
            Instantiate(eau, firePoint.position, firePoint.rotation);
            slider.value -= 1;
            yield return new WaitForSeconds(autoFireRate);
        }
    }

    #endregion
    

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
        Time.timeScale = 1f;
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    #endregion

}