using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedeController : MonoBehaviour
{
    public float moveSpeedHorizontal; 
    public float destroyOffset = 1f; 
    public float minXPosition = -3.5f; 
    public float maxXPosition = 3.5f; 
    public float minHeight = 3f; 
    public float maxHeight = 7f; 

    private Score score;


    void Start()
    {
        score = FindObjectOfType<Score>();

        moveSpeedHorizontal = score.GetSpeed(); 
        
        float height = Random.Range(minHeight, maxHeight);
        
        float randomX = Random.Range(minXPosition, maxXPosition);
        
        transform.localScale = new Vector3(1f, height, 1f);
    }

    void Update()
    {

        moveSpeedHorizontal = score.GetSpeed(); 

        
        transform.Translate(Vector2.left * moveSpeedHorizontal * Time.deltaTime);

        
        if (transform.position.x < (Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - destroyOffset))
        {
            Destroy(gameObject);
        }
    }
}
