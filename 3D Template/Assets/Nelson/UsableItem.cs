using System;
using UnityEngine;

[CreateAssetMenu]
public class UsableItem : Masks
{
    public bool IsUseable;
    public virtual void Use(PlayerStats playerstats, avatarMovement playermovement)
    {

    }
}
