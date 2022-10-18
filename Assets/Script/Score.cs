using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void onScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }
}
