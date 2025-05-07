using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    private ArmorSystem armorSystem;

    public float currentHealth;
    public TextMeshProUGUI healthAmountText;
    public HealthBar healthBar;
    private void Start()
    {
        armorSystem = GetComponent<ArmorSystem>();

        currentHealth = maxHealth;

        healthBar.SetSliderMax(maxHealth);
    }

    public void TakeDamge(float amount)
    {
        float finalDamage = armorSystem.CalculateDamage(amount);

        DecreaseHealth(finalDamage);

        currentHealth -= amount;
        healthBar.SetSlider(currentHealth);
    }
    public void Heal(float amount)
    {
        currentHealth += amount;
        healthBar.SetSlider(currentHealth);
    }
    private void Update()
    {
        healthAmountText.text = currentHealth + " / " + maxHealth;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        healthBar.SetSlider(currentHealth);
    }
    public float GetHealth()
    {
        return currentHealth;
    }
    private void Die()
    {
        Debug.Log("You are Dead");
        gameObject.SetActive(false);

        GameplayController.instance.RestartGame();
    }
}
