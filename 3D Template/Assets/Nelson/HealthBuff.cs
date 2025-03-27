using JetBrains.Annotations;
using UnityEngine;

public class HealthBuff : TailsmanEffects
{
    public float amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerStats>().maxHealth += amount;  
    }
}
