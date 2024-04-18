using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 
    private float scoreTimer = 1.0f; 
    private int score = 0;

    private float speed = 2f;

    private bool velocidadeAumentada = false;


    void Start()
    {
        SetScoreText();
    }

    void Update()
    {

        if (score % 350 == 0 && !velocidadeAumentada)
        {
            speed++;
            velocidadeAumentada = true;
        }
        else if (score % 200 != 0)
        {
            velocidadeAumentada = false; 
        }
        
        scoreTimer -= Time.deltaTime;

        
        if (scoreTimer <= 0)
        {
            score += 10; 
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


    public float GetSpeed(){
        return speed;
    }

    public int GetScore()
    {
        return score;
    }
}
