using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedeController : MonoBehaviour
{
    public float moveSpeedHorizontal = 3f; 
    public float destroyOffset = 1f; 
    public float minXPosition = -3.5f; 
    public float maxXPosition = 3.5f; 
    public float minHeight = 5f; 
    public float maxHeight = 14f; 

    void Start()
    {
        
        float height = Random.Range(minHeight, maxHeight);
        
        float randomX = Random.Range(minXPosition, maxXPosition);
        
        transform.localScale = new Vector3(1f, height, 1f);
    }

    void Update()
    {
        
        transform.Translate(Vector2.left * moveSpeedHorizontal * Time.deltaTime);

        
        if (transform.position.x < (Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - destroyOffset))
        {
            Destroy(gameObject);
        }
    }
}
