using UnityEngine;

public class Tailsman : MonoBehaviour
{
    public TailsmanEffects effect;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            effect.Apply(collision.gameObject);
        }
    }
}
