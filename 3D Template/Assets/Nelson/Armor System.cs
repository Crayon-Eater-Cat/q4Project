using TMPro;
using UnityEngine;

public class ArmorSystem : MonoBehaviour
{
    private float protectionAmount;
    [SerializeField] private TextMeshProUGUI protectionAmountText;

    private void Update()
    {
        protectionAmountText.text = protectionAmount.ToString();
    }
    public float CalculateDamage(float amount)
    {
        float finalDamage = amount - (amount * (protectionAmount / 100f));

        Mathf.Round(finalDamage);

        return finalDamage;
    }
}
