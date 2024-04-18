using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float upwardForce = 5f;
    public float maxYPosition = 4.5f;
    public float minYPosition = -4.5f;
    public float minXPosition = -8f;
    public float maxXPosition = 8f;
    public float gravityScale = 1f;
    
    public float moveSpeed = 2f; // Velocidade horizontal do personagem

    private Rigidbody2D rb;
    private Animator animator;
    
    private bool isFlying; // Se o personagem está voando ou não

    public float runningSpeed = 4f; // Velocidade de corrida do personagem
    private float defaultSpeed; // Velocidade padrão de caminhada

    private bool isRunning; // Se o personagem está correndo ou não

    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
        animator = GetComponent<Animator>();
        defaultSpeed = moveSpeed; // Armazena a velocidade inicial como a padrão de caminhada
    }

    void Update()
    {
      

        
        // Mover horizontalmente com base na entrada do usuário
        float horizontalInput = Input.GetAxis("Horizontal");
        
        // Verificar se o jogador quer correr e está no chão
        
        Debug.Log("IsRunning: " + isRunning); // Imprime o estado de corrida para depuração
        
        // Ajustar a velocidade de movimento dependendo se está correndo ou não
        moveSpeed = isRunning ? runningSpeed : defaultSpeed;
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        
        // Atualizar os parâmetros do Animator
       

        animator.SetBool("IsRunning", isRunning);
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        
        // Aplicar a força para cima se estiver voando
        isFlying = Input.GetKey(KeyCode.UpArrow);
        animator.SetBool("IsFlying", isFlying);
        if (isFlying)
        {
            rb.velocity = new Vector2(rb.velocity.x, upwardForce);
        }

        // Restrições para não ultrapassar os limites verticais do jogo
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
        // Visualizar a área de verificação do chão
        Gizmos.color = Color.red;
    }

    
}
