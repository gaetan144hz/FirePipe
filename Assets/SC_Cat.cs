using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SC_Cat : MonoBehaviour
{
    public float timeToDestroy;
    public SC_Score score;
    
    void Start()
    {
        timeToDestroy = Random.Range(4, 15);
        Destroy(this.gameObject, timeToDestroy);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Water"))
        {
            score = FindObjectOfType<SC_Score>();
            score.RemoveScore(1);
            Destroy(this.gameObject);
        }
    }
}
