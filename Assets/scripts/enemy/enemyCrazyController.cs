using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCrazyController : MonoBehaviour

{
    public float moveSpeedHorizontal; 
    public float moveSpeedVertical = 5f; 
    public float destroyOffset = 1f;
    public float minYPosition = -3.2f;
    public float maxYPosition = 3.2f;

    private Rigidbody2D rb;
    private bool movingUp = true;

    private Score score;

    void Start()
    {

        score = FindObjectOfType<Score>();

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * moveSpeedHorizontal;
    }

    void Update()
    {

        moveSpeedHorizontal = score.GetSpeed(); 
        rb.velocity = Vector2.left * moveSpeedHorizontal;

        if (transform.position.x < (Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - destroyOffset))
        {
            Destroy(gameObject);
        }

        if (movingUp)
        {
            rb.velocity = new Vector2(rb.velocity.x, moveSpeedVertical);
            if (transform.position.y >= maxYPosition)
                movingUp = false;
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -moveSpeedVertical);
            if (transform.position.y <= minYPosition)
                movingUp = true;
        }
    }
}
