using UnityEngine;

public class Walk : MonoBehaviour
{
    
    
    public float speed = 3f;

    private Rigidbody2D rbPlayer;
    private Vector2 input;

    private Animator animasiPlayer;
    private Vector2 LastMoveDirection;
    

    private SpriteRenderer spritePlayer;

    // Called once when the script instance is being loaded
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        animasiPlayer = GetComponent<Animator>();
        spritePlayer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        Animate();
        // Flip based on horizontal input
        
    }

    private void FixedUpdate()
    {
        if (rbPlayer != null)
        {
            rbPlayer.linearVelocity = input * speed;
        }
    }

    void ProcessInput()
    {
        float moveX = UnityEngine.Input.GetAxisRaw("Horizontal");
        float moveY = UnityEngine.Input.GetAxisRaw("Vertical");

        // store previous last move when player stops moving
        if (moveX == 0f && moveY == 0f && (input.x != 0f || input.y != 0f))
        {
            LastMoveDirection = input.normalized;
        }

        input = new Vector2(moveX, moveY);
        if (input.sqrMagnitude > 1f)
            input = input.normalized;
    }

    void Animate()
    {
        if (animasiPlayer == null)
            return;

        animasiPlayer.SetFloat("MoveX", input.x);
        animasiPlayer.SetFloat("MoveY", input.y);
        animasiPlayer.SetFloat("LastMoveX", LastMoveDirection.x);
        animasiPlayer.SetFloat("LastMoveY", LastMoveDirection.y);
        animasiPlayer.SetFloat("MoveMagnitude", input.magnitude);
    }

    
    
}