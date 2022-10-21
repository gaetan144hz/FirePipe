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
    
    [Header("Script")]
    public SC_Timer timer;
    public SC_Spawn hommeSpawn;
    public SC_SpawnCat catSpawn;

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

            Cursor.visible = true;
            gameOverUI.SetActive(true);
            scriptDestroy();
        }
    }

    public void scriptDestroy()
    {
        Destroy(this.gameObject.GetComponent<SC_Lance>());
        timer = FindObjectOfType<SC_Timer>();
        Destroy(timer.GetComponent<SC_Timer>());
        hommeSpawn = FindObjectOfType<SC_Spawn>();
        Destroy(hommeSpawn.GetComponent<SC_Spawn>());
        catSpawn = FindObjectOfType<SC_SpawnCat>();
        Destroy(catSpawn.GetComponent<SC_SpawnCat  >());
    }

    public void manBurn(int burnMan)
    {
        health -= burnMan;
    }
}
