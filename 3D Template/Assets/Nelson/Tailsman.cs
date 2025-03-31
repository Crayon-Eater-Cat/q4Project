using UnityEngine;

public class Tailsman : MonoBehaviour
{
    public TailsmanEffects effect;
    private void OnTriggerEnter(Collider collision)
    {
        Destroy(gameObject);
        effect.Apply(collision.gameObject);
    }
}
