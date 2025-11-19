using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public NewMonoBehaviourScript shield;  
    public int crystals = 30;
    public float shieldDuration = 8f;
    public UiManager uiManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // initial UI update
        uiManager.UpdateCrystals(crystals);
        uiManager.UpdateShieldStatus(false);
        uiManager.UpdateShieldTimer(0f);
    }

    // Update is called once per frame
    void Update()
    {
        uiManager.UpdateCrystals(crystals);
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
            shield.ActivateShield(shieldDuration, uiManager);
            Debug.Log("Shield used");
        }
        else
        {
            Debug.Log("No crystals!");
        }
    }
}
