using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int shield;

    private void Awake()
    {
        currentHealth = maxHealth;
        shield = 0;
    }

    public void TakeDamage(int amount)
    {
        int damageAfterShield = Mathf.Max(amount - shield, 0);
        shield = Mathf.Max(shield - amount, 0);
        currentHealth -= damageAfterShield;
        currentHealth = Mathf.Max(currentHealth, 0);
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    public void AddShield(int amount)
    {
        shield += amount;
    }
}