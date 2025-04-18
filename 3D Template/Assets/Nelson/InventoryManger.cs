using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManger : MonoBehaviour
{
    public static InventoryManger Instance;
    public List<InventoryItem> Items = new List<InventoryItem>();

    private void Awake()
    {
        Instance = this;
    }

    public void Add(InventoryItem item)
    {
        Items.Add(item);
    }

    public void Remove(InventoryItem item)
    {
        Items.Remove(item);
    }
}
