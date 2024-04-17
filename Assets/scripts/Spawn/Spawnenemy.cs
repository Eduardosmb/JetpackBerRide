using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInimigo : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public float spawnIntervalMin = 2f; 
    public float spawnIntervalMax = 7f; 
    private float spawnYMin = -3.2f; 
    public float spawnYMax = 3.2f;

    private Score score;

    void Start()
    {
        // Encontra a referência ao Score uma única vez no início
        score = FindObjectOfType<Score>();
        // Começa a tentar spawnar os inimigos
        InvokeRepeating("TrySpawnEnemy", spawnIntervalMin, spawnIntervalMax);
    }

    void TrySpawnEnemy()
    {
        // Verifica se o score é suficiente
        if (score != null && score.GetScore() >= 300)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        float randomY = Random.Range(spawnYMin, spawnYMax);
        Vector2 spawnPosition = new Vector2(12, randomY);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
