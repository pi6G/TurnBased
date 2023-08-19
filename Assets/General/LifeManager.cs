using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LifeManager
{
    private float maxLife;
    private float currentLife;

    public LifeManager(float maxLife) 
    {
        this.maxLife = maxLife;
        currentLife = maxLife;
    }

    public void TakeDmg(float dmgAmount)
    {
        currentLife -= dmgAmount;
        CheckLifeStatus();
    }

    private void CheckLifeStatus()
    {
        if (currentLife <= 0)
        {
            OnDeath();
            return;
        }

        if (currentLife > maxLife)
        {
            currentLife = maxLife;
        }
    }

    public abstract void OnDeath();
}
