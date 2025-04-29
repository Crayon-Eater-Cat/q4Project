using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu]
public class UsableItem : Masks
{
    public bool IsUseable;

    public List<UseableItemEffect> Effects;
    public virtual void Use(PlayerStats playerstats, avatarMovement playermovement)
    {
        foreach (UseableItemEffect effect in Effects)
        {
            effect.ExecuteEffect(this, playerstats, playermovement);
        }
    }
}
