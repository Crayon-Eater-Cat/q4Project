using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    InventoryItem item;

    public void AddItem(InventoryItem newItem)
    {
        item = newItem;
    }

    public void UseItem()
    {

    }
}
