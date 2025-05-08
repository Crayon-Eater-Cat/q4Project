using System.Collections;
using Unity.Burst.Intrinsics;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mask Penalty", menuName = "Item/Create New Mask Penalty")]
public class MaskPenalty : InventoryItem
{
    public void ExecuteEffect(PlayerStats playerstats, avatarMovement playermovement)
    {
        playermovement.mildinjuryseverity = 20f;
        playerstats.currentHealth = 150f;
        playerstats.maxHealth = 150;
        playermovement.setspeed = 5;
    }

    public void Undo(PlayerStats playerstats, avatarMovement playermovement)
    {

    }
}
