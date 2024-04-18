using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class LifeDisplay : MonoBehaviour
{
    public TextMeshProUGUI LifeText; 
    private PlayerCollision life;

    void Start()
    {
        life = FindObjectOfType<PlayerCollision>();
        SetLifeText();
    }

    void Update()
    {
        SetLifeText();
    }


    void SetLifeText()
    {
        LifeText.text = "Lifes: " + life.GetLife().ToString();
    }


    
}
