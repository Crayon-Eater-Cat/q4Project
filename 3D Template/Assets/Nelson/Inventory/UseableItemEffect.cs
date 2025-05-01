using UnityEngine;

public abstract class UseableItemEffect : ScriptableObject
{
    public abstract void ExecuteEffect( PlayerStats playerstats, avatarMovement playermovement);
}
