using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SC_Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI catText;
    public TextMeshProUGUI gameOverScoreText;
    public TextMeshProUGUI gameOverCatText;
    public int score;
    public int cat;
    
    void Start()
    {
        score = 0;
        cat = 0;
    }

    void Update()
    {
        
    }
    public void AddScore(int value)
    {
        score += value;
        scoreText.text = $"Sauve {score}";
        gameOverScoreText.text = $"Vous avez sauve {score} personnes BRAVO !";
        if (score == 0)
        {
            gameOverScoreText.text = $"T'abuse mon reuf ta sauve {score} personnes t nul";
        }    
    }

    public void RemoveScore(int value)
    {
        if (score >= 1)
        {
            score -= value;
            scoreText.text = $"Sauve {score}";
        }
        else
        {
            return;
        }
    }

    public void AddCat(int value)
    {
        cat += value;
        catText.text = $"Chat {cat}";
        gameOverCatText.text = $"Vous avez tue {cat} chat...";
    }
}
