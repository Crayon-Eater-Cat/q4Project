using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]

public class InventoryItem : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite icon;
    public UnityEvent effect;

    public void StartupMaskBlood()
    {
        FindFirstObjectByType<MaskBlood>().ApplyAffects();
    }

    public void StartupMaskBounding()
    {
        
    }

    public void StartupMaskPenalty()
    {

    }

    public void StartupMaskSignificance()
    {

    }

    public void StartupMaskSwiftness()
    {

    }
}
