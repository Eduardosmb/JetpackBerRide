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
        
        score = FindObjectOfType<Score>();
        
        InvokeRepeating("TrySpawnEnemy", spawnIntervalMin, spawnIntervalMax - spawnIntervalMin);
    }

    void TrySpawnEnemy()
    {
        
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
