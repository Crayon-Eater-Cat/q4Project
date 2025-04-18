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
}
