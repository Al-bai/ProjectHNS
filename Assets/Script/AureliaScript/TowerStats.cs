using UnityEngine;

public class TowerStats : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("Tower HP : " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("TOWER DESTROYED!");
    }
}
