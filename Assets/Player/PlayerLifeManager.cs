using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeManager : LifeManager
{
    public PlayerLifeManager(float maxLife) : base(maxLife) { }

    public override void OnDeath()
    {
        // death screen
        return;
    }
}
