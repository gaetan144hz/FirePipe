using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SC_Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverScoreText;
    public int score;
    
    void Start()
    {
        score = 0;
    }

    void Update()
    {
        
    }
    public void AddScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
        gameOverScoreText.text = $"Vous avez sauve {score} personnes BRAVO !";
        if (score == 0)
        {
            gameOverScoreText.text = $"T'abuse mon reuf ta sauve {score} personnes t nul";
        }
    }

    public void RemoveScore(int value)
    {
        score -= value;
        Debug.Log(value);
    }
}
