using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemyController : MonoBehaviour
{
    public float moveSpeedHorizontal = 3f;
    public float circleRadius = 2f; 
    public float angularSpeed = 2f; 
    public float destroyOffset = 1f;

    private float angle = 0f;
    private Vector3 centerPosition;

    void Start()
    {
        
        centerPosition = transform.position;
    }

    void Update()
    {
        
        centerPosition += Vector3.left * moveSpeedHorizontal * Time.deltaTime;

        
        angle += angularSpeed * Time.deltaTime;
        float x = Mathf.Cos(angle) * circleRadius;
        float y = Mathf.Sin(angle) * circleRadius;

        
        transform.position = centerPosition + new Vector3(x, y, 0f);

        
        if (transform.position.x < (Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - destroyOffset))
        {
            Destroy(gameObject);
        }
    }
}
