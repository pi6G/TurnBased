using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{
    public void Start()
    {
        base.InitHealth();
    }
    public override void OnDeath()
    {
        throw new System.NotImplementedException();
    }
    public override void DealDamage()
    {
        base.oponent.TakeDamage(PrecisionBar.precisionPercentage * 10);
    }
}
