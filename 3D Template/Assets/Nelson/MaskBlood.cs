using System.Collections;
using Unity.Burst.Intrinsics;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mask Blood", menuName = "Item/Create New Mask Blood")]
public class MaskBlood : InventoryItem
{
    public float duration;

    public void ExecuteEffect(PlayerStats playerstats, avatarMovement playermovement)
    {
        playerstats.StartCoroutine(DamageOverTimeCoroutine(playerstats, 20, 20));
    }

    IEnumerator DamageOverTimeCoroutine(PlayerStats stats, float damageAmount, float damageTime)
    {
        float amountDamaged = 0;
        float damagePerLoop = damageAmount / duration;
        while (amountDamaged < damageAmount)
        {
            stats.currentHealth -= damagePerLoop;
            Debug.Log(stats.currentHealth.ToString());
            amountDamaged += damagePerLoop;
            yield return new WaitForSeconds(1f);
        }
    }
}
