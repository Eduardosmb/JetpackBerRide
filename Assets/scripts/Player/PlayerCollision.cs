using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public int life = 3;  // Quantidade de vidas do jogador
    public AudioSource audioSource;  // Componente AudioSource para tocar os sons
    public AudioClip loseLifeSound;  // AudioClip que será tocado ao perder uma vida

    private float cooldown = 0f;  // Cooldown para invencibilidade temporária
    private bool isInvincible = false;  // Flag para controle de invencibilidade

    void Start() {
        // Garantir que o AudioSource está configurado
        if (audioSource == null) {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update() {
        // Verifica se o jogador está sem vidas e carrega a cena de Game Over
        if (life <= 0) {
            SceneManager.LoadScene("GameOver");
        }

        // Controle de cooldown para invencibilidade
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
                life -= 1;  // Decrementa uma vida
                isInvincible = true;  // Torna o jogador invencível temporariamente
                PlayLoseLifeSound();  // Toca o som de perda de vida
            }
        }
    }

    // Método para tocar o som de perda de vida
    private void PlayLoseLifeSound() {
        if (audioSource != null && loseLifeSound != null) {
            audioSource.PlayOneShot(loseLifeSound);
        }
    }

    public int GetLife() {
        return life;
    }
}
