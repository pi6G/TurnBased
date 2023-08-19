using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    protected LifeManager lifeManager;
    protected Creature oponent;

    public void TakeDamage(float damageAmount)
    {
        lifeManager.AddToHealth(-damageAmount);
    }

    public void TakeHealing(float healingAmount)
    {
        lifeManager.AddToHealth(healingAmount);
    }

    public void DealDamage(float damageAmount)
    {
        oponent.TakeDamage(damageAmount);
    }
}
