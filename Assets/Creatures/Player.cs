using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{
    public void Start()
    {
        base.initHealth();
        base.oponent = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
    }
    public override void OnDeath()
    {
        throw new System.NotImplementedException();
    }
}
