using System.Collections;
using Unity.Burst.Intrinsics;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mask Penalty", menuName = "Item/Create New Mask Penalty")]
public class MaskPenalty : InventoryItem
{
    public void ExecuteEffect(PlayerStats playerstats, avatarMovement playermovement)
    {
        playermovement.mildinjuryseverity = 20f;
    }
}
