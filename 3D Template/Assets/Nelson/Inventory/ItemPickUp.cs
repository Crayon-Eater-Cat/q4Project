using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemPickUp : MonoBehaviour
{
    public InventoryItem Item;

    void Pickup()
    {
        InventoryManger.Instance.Add(Item);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
