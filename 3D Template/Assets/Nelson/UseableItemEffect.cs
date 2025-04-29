using UnityEngine;

public abstract class UseableItemEffect : ScriptableObject
{
    public abstract void ExecuteEffect(UsableItem parentItem, PlayerStats playerstats, avatarMovement playermovement);
}
