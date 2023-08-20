using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{
    [SerializeField] private float health;

    public void Start()
    {
        base.oponent = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();

        base.lifeManager = new PlayerLifeManager(health);
    }
}
