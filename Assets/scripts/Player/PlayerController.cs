using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float upwardForce = 5f; 
    public float maxYPosition = 4.5f;
    public float minYPosition = -4.5f;
    public float gravityScale = 1f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, upwardForce);
        }

        if (transform.position.y > maxYPosition)
        {
            transform.position = new Vector2(transform.position.x, maxYPosition);
            rb.velocity = Vector2.zero;
        }

        if (transform.position.y < minYPosition)
        {
            transform.position = new Vector2(transform.position.x, minYPosition);
            rb.velocity = Vector2.zero;
        }
    }
}
