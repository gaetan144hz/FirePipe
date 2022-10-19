using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public GameObject[] hearth;
    public SpriteRenderer spriteHead;

    void Start()
    {
        health = 3;
    }
    
    void Update()
    {
        if (health == 3)
        {
            foreach (GameObject head in hearth)
            {
                //head.gameObject.GetComponent<SpriteRenderer>().sprite = spriteHead;
            }
        }
    }

    public void manBurn(int burnMan)
    {
        health -= burnMan;
    }
}
