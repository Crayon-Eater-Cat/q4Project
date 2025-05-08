using System.Collections;
using System.Diagnostics.CodeAnalysis;
using Unity.Burst.Intrinsics;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mask Swiftness", menuName = "Item/Create New Mask Swiftness")]
public class MaskSwiftness : InventoryItem
{
    public void ExecuteEffect(PlayerStats playerstats, avatarMovement playermovement)
    {
        playermovement.setspeed = 20f;

        playerstats.currentHealth = 50f;
        playerstats.maxHealth = 50f;
    }

    public void Undo(PlayerStats playerstats, avatarMovement playermovement)
    {
        
    }
}
