using Assets.FPSTesting.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthPotion : BringableObject {

    public int amount;
    public Sprite sprite;

    public override void Use(ref Player player)
    {
        player.GiveHealth(amount);
    }
}
