using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public int life = 3;  
    public AudioSource audioSource;  
    public AudioClip loseLifeSound;  

    private float cooldown = 0f;  
    private bool isInvincible = false;  

    void Start() {
        
        if (audioSource == null) {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update() {
        
        if (life <= 0) {
            SceneManager.LoadScene("GameOver");
        }

        
        if (isInvincible) {
            cooldown += Time.deltaTime;
            if (cooldown >= 1f) {
                isInvincible = false;
                cooldown = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!isInvincible) {
            if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Parede")) {
                life -= 1;  
                isInvincible = true;  
                PlayLoseLifeSound();  
            }
        }
    }

    
    private void PlayLoseLifeSound() {
        if (audioSource != null && loseLifeSound != null) {
            audioSource.PlayOneShot(loseLifeSound);
        }
    }

    public int GetLife() {
        return life;
    }
}
