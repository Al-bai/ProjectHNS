using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [Header("Enemy Stats")]
    public float maxHealth = 30f;
    private float currentHealth;

    [Header("Movement")]
    public float moveSpeed = 1.5f;

    private Rigidbody2D rbEnemy;
    private Animator animEnemy;

    private Vector2 moveDirection = Vector2.left;  

    void Start()
    {
        currentHealth = maxHealth;

        rbEnemy = GetComponent<Rigidbody2D>();
        animEnemy = GetComponent<Animator>();
    }

    void Update()
    {
        Animate();
    }

    private void FixedUpdate()
    {
        rbEnemy.linearVelocity = moveDirection * moveSpeed;
    }

    void Animate()
    {
        if (animEnemy == null)
            return;

        bool isWalking = moveSpeed > 0.05f; 
        animEnemy.SetBool("isWalking", isWalking);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}


