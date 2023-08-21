using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{
    public void Start()
    {
        base.InitHealth();
        base.oponent = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public override void OnDeath()
    {
        FindObjectOfType<CreatureUtilities>().SpawnNextEnemy();
        Destroy(gameObject);
    }

    public override void DealDamage()
    {
        base.oponent.TakeDamage(UnityEngine.Random.Range(5, 30));
    }
}
