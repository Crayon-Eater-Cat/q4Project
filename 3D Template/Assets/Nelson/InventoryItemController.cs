using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    InventoryItem item;

    public void AddItem(InventoryItem newItem)
    {
        item = newItem;
    }

    public void InventoryRightClick(InventoryItem item)
    {
        item.effect.Invoke(FindFirstObjectByType<PlayerStats>(), FindFirstObjectByType<avatarMovement>());
    }
}
