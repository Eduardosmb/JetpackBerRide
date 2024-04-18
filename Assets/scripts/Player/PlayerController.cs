using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float upwardForce = 5f;
    public float maxYPosition = 4.5f;
    public float minYPosition = -4.5f;
    public float minXPosition = -8f;
    public float maxXPosition = 8f;
    public float gravityScale = 1f;
    
    public float moveSpeed = 2f; 

    private Rigidbody2D rb;
    private Animator animator;
    
    private bool isFlying; 

    public float runningSpeed = 4f; 
    private float defaultSpeed; 

    private bool isRunning; 

    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
        animator = GetComponent<Animator>();
        defaultSpeed = moveSpeed; 
    }

    void Update()
    {
      

        
        
        float horizontalInput = Input.GetAxis("Horizontal");
        
        
        
        Debug.Log("IsRunning: " + isRunning); 
        
        
        moveSpeed = isRunning ? runningSpeed : defaultSpeed;
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        
        
       

        animator.SetBool("IsRunning", isRunning);
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        
        
        isFlying = Input.GetKey(KeyCode.UpArrow);
        animator.SetBool("IsFlying", isFlying);
        if (isFlying)
        {
            rb.velocity = new Vector2(rb.velocity.x, upwardForce);
        }

        
        ClampYPosition();
    }


    void ClampYPosition()
    {
        if (transform.position.y > maxYPosition)
        {
            transform.position = new Vector2(transform.position.x, maxYPosition);
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        else if (transform.position.y < minYPosition)
        {
            transform.position = new Vector2(transform.position.x, minYPosition);
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        
        if (transform.position.x < minXPosition){
            transform.position = new Vector2(minXPosition, transform.position.y);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else if (transform.position.x > maxXPosition){
            transform.position = new Vector2(maxXPosition, transform.position.y);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        

    }


    void OnDrawGizmos()
    {
        
        Gizmos.color = Color.red;
    }

    
}
