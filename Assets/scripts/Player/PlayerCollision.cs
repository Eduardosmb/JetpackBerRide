using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{

    public int life = 3;

    private float cooldown = 0f;

    private bool isInvincible = false;


    void Update()
    {
        if (life <= 0){
            SceneManager.LoadScene("GameOver");
        }
        if(isInvincible){
            cooldown += Time.deltaTime;
            if(cooldown >= 2f){
                isInvincible = false;
                cooldown = 0f;
            }
        }


    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        if(!isInvincible){
            if(other.gameObject.CompareTag("enemy")){
                Debug.Log("ergi gay da o butico na esquina da casa do ator depois de perder no poker");
                life -= 1;
                isInvincible = true;
            }
            if(other.gameObject.CompareTag("Parede")){
                Debug.Log("tomo troxa");
                life -= 1;
                isInvincible = true;

            }
        }
        
    }

    
}
