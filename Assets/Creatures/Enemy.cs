using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{
    [SerializeField] private float randomness;
    public void Start()
    {
        base.InitComponents();
        base.oponent = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public override void OnDeath()
    {
        FindObjectOfType<CreatureUtilities>().SpawnNextEnemy();
        Destroy(gameObject);
    }

    public override void Attack()
    {
        base.oponent.ChangeLife(-UnityEngine.Random.Range(1f - randomness, 1f) * 10f * base.weapon.attackBoost / base.oponent.suit.defenseBoost);
    }

    public override void SuperAttack()
    {
        base.oponent.ChangeLife(-UnityEngine.Random.Range(1f - randomness, 1f) * 30f * base.hat.skillBoost / base.oponent.suit.defenseBoost);
    }

    public override void Heal()
    {
        if (base.currentStamina == base.maxStamina)
        {
            base.ChangeLife(-UnityEngine.Random.Range(1f - randomness, 1f) * 10f);
            base.currentStamina = 0f;
        }
    }
    public override void OnEndTurn()
    {
        if (base.currentStamina < base.maxStamina)
        {
            ++base.currentStamina;
        }

        Heal();
    }
}
