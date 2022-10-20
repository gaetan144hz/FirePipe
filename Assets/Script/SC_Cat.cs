using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SC_Cat : MonoBehaviour
{
    public int index;
    
    private float timeToDestroy;
    public SC_Score score;
    public SC_SpawnCat spawn;
    
    public string newTag;
    
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
            this.gameObject.tag = newTag;
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        if (this.gameObject.CompareTag("Watered"))
        {
            score = FindObjectOfType<SC_Score>();
            score.RemoveScore(1);
            score.AddCat(1);
            spawn.ResetSpawnPoint(index);
        }
        else
        {
            return;
        }
    }
}
