using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public Player playerStats;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI shieldText;

    private void Update()
    {
        healthText.text = "HP: " + playerStats.currentHealth;
        shieldText.text = "Shield: " + playerStats.shield;
    }
}