using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_SlideMovement : MonoBehaviour
{
    public bool moveRight;

    [Header("Range")]
    [SerializeField] private float rangeRight;
    [SerializeField] private float rangeLeft;
    [SerializeField] private float currentSpeedMovement;

    // Start is called before the first frame update
    void Start()
    {
        //moveSpeed = 2f;
        moveRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > rangeRight)
        {
            moveRight = false;
        }
        else if (transform.position.x < rangeLeft)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.position = new Vector2(transform.position.x + currentSpeedMovement * Time.deltaTime, transform.position.y);
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            transform.position = new Vector2(transform.position.x - currentSpeedMovement * Time.deltaTime, transform.position.y);
        }
    }
}