using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SC_Health : MonoBehaviour
{
    public int health;
    
    [Header("GameObject")]
    public GameObject[] hearth;
    public GameObject[] headLight;
    public GameObject gameOverUI;

    [Header("Sprite")]
    public Sprite spriteHead;
    public Sprite spriteBurnHead;

    void Start()
    {
        health = 3;
        gameOverUI.SetActive(false);
        
        foreach (var light in headLight)
        {
            light.SetActive(true);
        }

        foreach (var head in hearth)
        {
            head.gameObject.GetComponent<SpriteRenderer>().sprite = spriteHead;
        }
    }
    
    void Update()
    {
        if (health == 2)
        {
            hearth[0].gameObject.GetComponent<SpriteRenderer>().sprite = spriteBurnHead;
            headLight[0].SetActive(false);
        }

        if (health == 1)
        {
            hearth[1].gameObject.GetComponent<SpriteRenderer>().sprite = spriteBurnHead;
            headLight[1].SetActive(false);
        }

        if (health == 0)
        {
            foreach (var head in hearth)
            {
                head.GetComponent<SpriteRenderer>().sprite = spriteBurnHead;
            }

            foreach (var light in headLight)
            {
                light.SetActive(false);
            }
            
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void manBurn(int burnMan)
    {
        health -= burnMan;
    }
}
