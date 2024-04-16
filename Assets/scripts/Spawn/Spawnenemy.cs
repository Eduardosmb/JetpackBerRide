using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInimigo : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public float spawnIntervalMin = 1f; 
    public float spawnIntervalMax = 3f; 
    private float spawnYMin = -3.2f; 
    public float spawnYMax = 3.2f; 

    void Start()
    {
        Invoke("SpawnEnemy", Random.Range(spawnIntervalMin, spawnIntervalMax));
    }

    void SpawnEnemy()
    {
        float randomY = Random.Range(spawnYMin, spawnYMax);

        Vector2 spawnPosition = new Vector2(12, randomY);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        Invoke("SpawnEnemy", Random.Range(spawnIntervalMin, spawnIntervalMax));
    }
}

