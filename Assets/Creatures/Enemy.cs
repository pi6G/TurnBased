using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{
    [SerializeField] private float randomness;
    public void Start()
    {
        base.InitComponents();
        base.currentStamina = 0;
        base.oponent = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public override void OnDeath()
    {
        FindObjectOfType<CreatureUtilities>().SpawnNextEnemy();
        Destroy(gameObject);
    }

    public override void Attack()
    {
        base.oponent.ChangeLife(-UnityEngine.Random.Range(1f - randomness, 1f) * 5f * base.weapon.attackBoost / base.oponent.suit.defenseBoost);
        animations.Attack();
    }

    public override void SuperAttack()
    {
        base.oponent.ChangeLife(-UnityEngine.Random.Range(1f - randomness, 1f) * 15f * base.hat.skillBoost / base.oponent.suit.defenseBoost);
        animations.Attack();
    }

    public override void Heal()
    {
        if (base.canUseSkill())
        {
            base.ChangeLife(UnityEngine.Random.Range(1f - randomness, 1f) * 15f);
            base.currentStamina = 0f;
            animations.Heal();
        }
    }
    public override void OnEndTurn()
    {
        if (!base.canUseSkill())
        {
            Attack();
            ++base.currentStamina;
            return;
        }

        if (UnityEngine.Random.Range(0, 1f) > 0.5f)
        {
            Heal();
        }
        else
        {
            SuperAttack();
        }
    }
}
