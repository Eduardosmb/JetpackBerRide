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
        
        score = FindObjectOfType<Score>();
        
        InvokeRepeating("TrySpawnEnemy", spawnIntervalMin, spawnIntervalMax);
    }

    void TrySpawnEnemy()
    {
        
        if (score != null && score.GetScore() >= 500)
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
