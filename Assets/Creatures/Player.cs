using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{
    public void Start()
    {
        base.InitComponents();
    }
    public override void OnDeath()
    {
        throw new System.NotImplementedException();
    }
    public override void Attack()
    {
        base.oponent.ChangeLife(-PrecisionBar.precisionPercentage * 10f * base.weapon.attackBoost / base.oponent.suit.defenseBoost);
    }
    public override void SuperAttack()
    {
        base.oponent.ChangeLife(-PrecisionBar.precisionPercentage * 30f * base.hat.skillBoost / base.oponent.suit.defenseBoost);
    }
    public override void Heal()
    {
        if (base.currentStamina == base.maxStamina)
        {
            base.ChangeLife(PrecisionBar.precisionPercentage * 10f);
            base.currentStamina = 0f;
        }
    }

    public override void OnEndTurn()
    {
        if (base.currentStamina < base.maxStamina)
        {
            ++base.currentStamina;
        }
    }
}
