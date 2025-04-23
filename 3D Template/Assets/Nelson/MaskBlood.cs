using System.Collections;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class MaskBlood : Masks
{
    public float duration;

    public override void ApplyAffects()
    {
        this.ApplyAffects();
        Debug.Log("Bleh");
    }

    public void DamageOverTime(int damageAmount, int damageTime)
    {
        StartCoroutine(DamageOverTimeCoroutine(damageAmount, damageTime));
    }

    IEnumerator DamageOverTimeCoroutine(float damageAmount, float damageTime)
    {
        float amountDamaged = 0;
        float damagePerLoop = damageAmount / duration;
        while (amountDamaged < damageAmount)
        {
            PlayerStats stats = GetComponent<PlayerStats>();
            stats.currentHealth -= damagePerLoop;
            Debug.Log(stats.currentHealth.ToString());
            amountDamaged += damagePerLoop;
            yield return new WaitForSeconds(1f);
        }
    }
}
