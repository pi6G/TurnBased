using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{
    public void Start()
    {
        base.initHealth();
        base.oponent = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public override void OnDeath()
    {
        throw new System.NotImplementedException();
    }
}
