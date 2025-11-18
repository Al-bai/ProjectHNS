using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public NewMonoBehaviourScript shield;  
    public int crystals = 30;
    public float shieldDuration = 8f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          if (Input.GetKeyDown(KeyCode.C))
        {
            TryActivateShield();
        }
    }

    private void TryActivateShield()
    {
        if (crystals > 0)
        {
            crystals--;
            shield.ActivateShield(shieldDuration);
            Debug.Log("Shield used");
        }
        else
        {
            Debug.Log("No crystals!");
        }
    }
}
