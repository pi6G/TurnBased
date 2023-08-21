using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{
    public void Start()
    {
        base.InitComponents();
        base.currentStamina = base.maxStamina;
    }

    public override void OnDeath()
    {
        throw new System.NotImplementedException();
    }

    public override void Attack()
    {
        base.oponent.ChangeLife(-PrecisionBar.precisionPercentage * 10f * base.weapon.attackBoost / base.oponent.suit.defenseBoost);
        animations.Attack();
    }

    public override void SuperAttack()
    {
        if (base.canUseSkill())
        {
            base.currentStamina = 0f;
            base.oponent.ChangeLife(-PrecisionBar.precisionPercentage * 30f * base.hat.skillBoost / base.oponent.suit.defenseBoost);
            animations.Attack();
        }
    }

    public override void Heal()
    {
        if (base.canUseSkill())
        {
            base.currentStamina = 0f;
            base.ChangeLife(PrecisionBar.precisionPercentage * 30f);
            animations.Heal();
        }
    }

    public override void OnEndTurn()
    {
        if (!base.canUseSkill())
        {
            ++base.currentStamina;
        }
    }
}
