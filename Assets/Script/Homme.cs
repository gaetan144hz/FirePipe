using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homme : MonoBehaviour
{
    private Score score;

    [SerializeField] float currenTime = 0f;
    [SerializeField] float startingTime = 10f;

    public Sprite spriteHomme;
    public float timeToDestroy;
    
    public Gradient lifeGradient;
    public SpriteRenderer spritePlayer;

    void Awake()
    {
        score = FindObjectOfType<Score>();
    }

    private void Start()
    {
        currenTime = startingTime;
    }

    void Update()
    {
        currenTime -= 1 * Time.deltaTime;

        spritePlayer.color = lifeGradient.Evaluate(currenTime / startingTime);
        if (currenTime <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        Destroy(this.gameObject,timeToDestroy);
    }

    public void OnDestroy()
    {
        score.onScore(1);
    }
}
