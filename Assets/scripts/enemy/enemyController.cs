using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float moveSpeed; 
    public float destroyOffset = 1f; 

    private Rigidbody2D rb;

    private Score score;

    void Start()
    {
        score = FindObjectOfType<Score>();

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * moveSpeed;
    }

    void Update()
    {
        moveSpeed = score.GetSpeed(); 
        rb.velocity = Vector2.left * moveSpeed;

        if (transform.position.x < (Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - destroyOffset))
        {
            Destroy(gameObject);
        }
    }
}
