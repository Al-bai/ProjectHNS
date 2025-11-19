using UnityEngine;
using TMPro;


public class UiManager : MonoBehaviour
{

    public TextMeshProUGUI crystalsText;
    public TextMeshProUGUI shieldStatusText;
    public TextMeshProUGUI shieldTimerText;
    

    public void UpdateCrystals(int amount)
    {
        crystalsText.text = "Crystals: " + amount;
    }

    public void UpdateShieldStatus(bool isActive)
    {
        if (isActive)
            shieldStatusText.text = "Shield: ACTIVE";
        else
            shieldStatusText.text = "Shield: INACTIVE";
    }

    public void UpdateShieldTimer(float timeRemaining)
    {
        shieldTimerText.text = "Shield Time: " + timeRemaining.ToString("F1") + " s";
    }
}
