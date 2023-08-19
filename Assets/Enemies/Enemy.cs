using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{
    [SerializeField] private EnemySO enemySO;
    private SpriteRenderer spriteRenderer;

    public void Start()
    {
        base.lifeManager = new EnemyLifeManager(enemySO.health);
        
        base.oponent = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = enemySO.sprite;
    }
}
