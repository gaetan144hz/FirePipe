using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_Homme : MonoBehaviour
{
    public int index;
    public bool watered;
    public GameObject bgFire;
    
    [Header("Script")]
    private SC_Score score;
    private SC_Health health;
    public SC_Spawn spawn;
    

    [Header("Timer")]
    public float currenTime = 0f;
    public float startingTime = 10f;

    [Header("Sprite")]
    public Sprite spriteRescueMan;
    public float timeToDestroy;
    public Gradient lifeGradient;
    public SpriteRenderer spritePlayer;

    [Header("Tag")] 
    public string newTag;

    void Awake()
    {
        score = FindObjectOfType<SC_Score>();
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
            bgFire.SetActive(false);
            this.gameObject.tag = newTag;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteRescueMan;
            Destroy(this.gameObject,1f);
            
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
        
        if (this.gameObject.CompareTag("Saved"))
        {
            score = FindObjectOfType<SC_Score>();
            score.onScore(1);
        }

        if (this.gameObject.CompareTag("homme_feu"))
        {
            health = FindObjectOfType<SC_Health>();
            health.manBurn(1);
        }
    }
}
