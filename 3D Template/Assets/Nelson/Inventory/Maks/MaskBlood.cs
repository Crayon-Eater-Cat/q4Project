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

    public void Undo(PlayerStats playerstats, avatarMovement playermovement)
    {

    }

    IEnumerator DamageOverTimeCoroutine(PlayerStats stats, float damageAmount, float damageTime)
    {
        float amountDamaged = 0;
        float damagePerLoop = damageAmount / duration;
        while (amountDamaged < damageAmount)
        {
            //Current health is a private variable as public variables cannot be modified except in the inspector. Use these functions alternatively.
            stats.DecreaseHealth(damagePerLoop);
            Debug.Log(stats.GetHealth().ToString());
            amountDamaged += damagePerLoop;
            yield return new WaitForSeconds(1f);
        }
    }
}
