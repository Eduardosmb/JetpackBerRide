using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CricleEnemyController : MonoBehaviour
{
    public float moveSpeedHorizontal = 3f;
    public float circleRadius = 2f; 
    public float angularSpeed = 2f; 
    public float destroyOffset = 1f;

    private float angle = 0f;

    void Update()
    {
        transform.Translate(Vector2.left * moveSpeedHorizontal * Time.deltaTime);

        angle += angularSpeed * Time.deltaTime;
        float x = Mathf.Cos(angle) * circleRadius;
        float y = Mathf.Sin(angle) * circleRadius;
        Vector3 circleMovement = new Vector3(x, y, 0f);
        transform.position += circleMovement;

        if (transform.position.x < (Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - destroyOffset))
        {
            Destroy(gameObject);
        }
    }
}
