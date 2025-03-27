using UnityEngine;

public class ArmorPart : MonoBehaviour
{
    [SerializeField] private float protectionValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<ArmorSystem>().AddArmor(protectionValue, gameObject);
            Destroy(gameObject);
        }
    }
}
