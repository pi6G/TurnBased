using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureUtilities : MonoBehaviour
{
    private static int currentEnemy;
    public Enemy[] enemies;

    private Player player;
    private UIStateManager stateManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        stateManager = FindObjectOfType<UIStateManager>();
        currentEnemy = 0;
    }

    public void SpawnNextEnemy()
    {
        player.oponent = Instantiate(enemies[currentEnemy]);

        if (currentEnemy == enemies.Length) stateManager.OnWin();
        
        ++currentEnemy;
    }
}
