using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeManager : LifeManager
{
    public EnemyLifeManager(float maxLife) : base(maxLife) { }

    public override void OnDeath()
    {
        // nextEnemy
        return;
    }
}
