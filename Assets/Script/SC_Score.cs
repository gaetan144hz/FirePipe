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
        if (score == 0)
        {
            gameOverScoreText.text = $"T'abuse mon reuf ta sauvé personnes t nul";
        }
        if (cat == 0)
        {
            gameOverCatText.text = $"Vous n'avez pas tué de chat";
        }
    }
    public void AddScore(int value)
    {
        score += value;
        scoreText.text = $"Sauve {score}";
        gameOverScoreText.text = $"Vous avez sauvé(s) {score} personnes BRAVO !";
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
            scoreText.text = $"Sauve: {score}";
        }
        gameOverScoreText.text = $"Vous avez sauvé(s) {score} personne(s) BRAVO !";
    }

    public void AddCat(int value)
    {
        cat += value;
        catText.text = $"Chat tué: {cat}";
        gameOverCatText.text = $"Vous avez tué(s) {cat} chat(s)... ..";
    }
}
