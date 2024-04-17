using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 
    private float scoreTimer = 1.0f; 
    private int score = 0;

    void Start()
    {
        SetScoreText();
    }

    void Update()
    {
        
        scoreTimer -= Time.deltaTime;

        
        if (scoreTimer <= 0)
        {
            score += 20; 
            SetScoreText(); 
            scoreTimer = 1.0f; 
        }
    }


    void SetScoreText()
    {
        if(scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogError("scoreText não está atribuído no Inspector");
        }
    }

    public int GetScore()
    {
        return score;
    }
}
