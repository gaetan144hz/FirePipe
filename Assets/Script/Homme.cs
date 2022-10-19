using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Homme : MonoBehaviour
{
    public int index;
    private Score score;
    public Spawn spawn;
    public bool watered;

    [Header("Timer")]
    public float currenTime = 0f;
    public float startingTime = 10f;

    [Header("Sprite")]
    public Sprite spriteHomme;
    public float timeToDestroy;
    public Gradient lifeGradient;
    public SpriteRenderer spritePlayer;

    [Header("Tag")] 
    public string newTag;

    void Awake()
    {
        score = FindObjectOfType<Score>();
    }

    private void Start()
    {
        this.gameObject.tag = "homme_feu";
        currenTime = startingTime;
        watered = false;
    }

    void Update()
    {
        currenTime -= 1f * Time.deltaTime;

        if (watered == false)
        {
            spritePlayer.color = lifeGradient.Evaluate(currenTime / startingTime);
        }

        if (currenTime <= 0f)
        {
            Die();
        }

        if (currenTime >= 15f)
        {
            this.gameObject.tag = newTag;
            Debug.Log(newTag);
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            Destroy(this.gameObject,0.1f);
            
        }
    }

    public void addTime(int value)
    {
        currenTime += value;
    }
    
    public void Die()
    {
        Destroy(this.gameObject,timeToDestroy);
    }

    private void OnDestroy()
    {
        spawn.ResetSpawnPoint(index);
        
        if (this.gameObject.CompareTag("homme"))
        {
            score.onScore(+1);
        }

        if (this.gameObject.CompareTag("homme_feu"))
        {
            score.onScore(-1);
        }
    }
}
