using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LifeManager
{
    private float maxHealth;
    private float currentHealth;

    public LifeManager(float maxHealth) 
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
    }

    // this method can be used to take damage or healing
    public void AddToHealth(float changeAmount)
    {
        currentHealth += changeAmount;
        CheckLifeStatus();
    }

    private void CheckLifeStatus()
    {
        if (currentHealth <= 0)
        {
            OnDeath();
            return;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public abstract void OnDeath();
}
