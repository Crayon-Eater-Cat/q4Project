using UnityEngine;
using UnityEngine.Rendering;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    
    private float currentHealth;

    public HealthBar healthBar;
    private void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetSliderMax(maxHealth);
    }

    public void TakeDamge(float amount)
    {
        currentHealth -= amount;
        healthBar.SetSlider(currentHealth);
    }
}
