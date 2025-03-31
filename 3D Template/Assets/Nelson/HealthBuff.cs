using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(menuName = "Tailsman/HealthBuff")]
public class HealthBuff : TailsmanEffects
{
    public float amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerStats>().maxHealth += amount;  
    }
}
