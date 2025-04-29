using UnityEngine;
using UnityEngine.Events;

public class InventoryItem : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite icon;
    public UnityEvent<PlayerStats, avatarMovement> effect;
}
