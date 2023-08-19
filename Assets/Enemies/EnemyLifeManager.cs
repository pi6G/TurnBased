using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeManager : LifeManager
{
    public EnemyLifeManager(float maxHealth) : base(maxHealth) { }

    public override void OnDeath()
    {
        // nextEnemy
        return;
    }
}
