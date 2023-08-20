using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Creature : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    public float currentHealth;

    protected Creature oponent;
    [SerializeField] protected Image healthBar;

    protected void initHealth()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, currentHealth / maxHealth, Time.deltaTime * 5f);
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        CheckLifeStatus();
    }

    public void TakeHealing(float healingAmount)
    {
        currentHealth += healingAmount;
        CheckLifeStatus();
    }

    public void DealDamage(float damageAmount)
    {
        oponent.TakeDamage(damageAmount);
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
