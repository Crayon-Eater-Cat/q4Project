using TMPro;
using UnityEngine;

public class ArmorSystem : MonoBehaviour
{
    private float protectionAmount;
    [SerializeField] GameObject armorHolder;
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

    public void AddArmor(float amount, GameObject prefab)
    {
        protectionAmount = amount;

        for (int i = armorHolder.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(armorHolder.transform.GetChild(i).gameObject);  
        }

        prefab.transform.SetParent(armorHolder.transform);
        prefab.transform.position = transform.position;
    }
}
