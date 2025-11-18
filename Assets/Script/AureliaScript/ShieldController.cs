using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float duration = 8f;            // durasi shield aktif
    public float damagePerSecond = 10f;    // damage ke musuh tiap detik
    
    private float timer;
    private bool isActive = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            DeactivateShield();
        }

    }

    public void ActivateShield(float newDuration)
    {
        duration = newDuration;
        timer = duration;

        isActive = true;
        gameObject.SetActive(true);
    }

    private void DeactivateShield()
    {
        isActive = false;
        gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isActive) return;

        if (other.CompareTag("Enemy"))
        {
            EnemyController e = other.GetComponent<EnemyController>();
            if (e != null)
            {
                e.TakeDamage(damagePerSecond * Time.deltaTime);
            }
        }
    }

}    
