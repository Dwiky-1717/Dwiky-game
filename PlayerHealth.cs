using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Slider healthBar;
    public Image fillImage;

    void Start()
    {
        currentHealth = maxHealth;

        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        UpdateHealthColor();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        healthBar.value = currentHealth;

        UpdateHealthColor();

        Debug.Log("Player kena damage! HP sekarang: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthColor()
    {
        float healthPercent = (float)currentHealth / maxHealth;

        if (healthPercent > 0.5f)
        {
            fillImage.color = Color.green;
        }
        else if (healthPercent > 0.2f)
        {
            fillImage.color = Color.yellow;
        }
        else
        {
            fillImage.color = Color.red;
        }
    }

    void Die()
    {
        Debug.Log("Player Mati!");
        gameObject.SetActive(false);
    }
}