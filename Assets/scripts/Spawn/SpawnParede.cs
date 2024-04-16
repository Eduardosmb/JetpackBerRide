using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParede : MonoBehaviour
{
    public GameObject paredePrefab; 
    public float spawnIntervalMin = 2f; 
    public float spawnIntervalMax = 4f;

    void Start()
    {
        Invoke("SpawnNovaParede", Random.Range(spawnIntervalMin, spawnIntervalMax));
    }

    void SpawnNovaParede()
    {
        float posY = Random.Range(0, 2) == 0 ? -3.5f : 3.5f;
        
        float scaleY = Random.Range(5f, 14f);
        Vector3 scale = new Vector3(1f, scaleY, 1f);
        
        Vector2 spawnPosition = new Vector2(12f, posY);
        GameObject novaParede = Instantiate(paredePrefab, spawnPosition, Quaternion.identity);
        novaParede.transform.localScale = scale;

        Invoke("SpawnNovaParede", Random.Range(spawnIntervalMin, spawnIntervalMax));
    }
}
