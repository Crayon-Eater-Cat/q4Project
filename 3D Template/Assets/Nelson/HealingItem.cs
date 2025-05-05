using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public float healAmount;
    PlayerStats health;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && health.currentHealth > health.maxHealth)
        {
            other.GetComponent<PlayerStats>().Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
