using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCircleEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    private Score score;
    public float spawnIntervalMin = 2f;
    public float spawnIntervalMax = 5f;
    public float spawnYMin = -3.2f;
    public float spawnYMax = 3.2f;

    void Start()
    {
        // Encontre a referência ao Score uma única vez no início
        score = FindObjectOfType<Score>();
        // Começa a tentar spawnar os inimigos
        InvokeRepeating("TrySpawnEnemy", spawnIntervalMin, spawnIntervalMax - spawnIntervalMin);
    }

    void TrySpawnEnemy()
    {
        // Verifica se o score é suficiente
        if (score.GetScore() >= 100)
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
