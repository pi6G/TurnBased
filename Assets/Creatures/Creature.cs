using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Creature : MonoBehaviour
{
    [HideInInspector] public Creature oponent;

    [Header("HEALTH")]
    [SerializeField] private Image healthBar;
    [SerializeField] private float maxHealth;
    private float currentHealth;

    [Header("STAMINA")]
    [SerializeField] private Image staminaBar;
    [SerializeField] protected float maxStamina;
    protected float currentStamina;

    [Header("BODY")]
    [SerializeField] private Transform head;
    [SerializeField] private Transform hand;

    [SerializeField] protected Animations animations;

    [Header("SPRITE RENDERERS")]
    [SerializeField] private SpriteRenderer suitSR;
    [SerializeField] private SpriteRenderer hatSR;
    [SerializeField] private SpriteRenderer weaponSR;

    [Header("EQUIPMENT")]
    public Suit suit;
    public Hat hat;
    public Weapon weapon;

    protected void InitComponents()
    {
        currentHealth = maxHealth;
        RefreshSprites();
    }

    protected void RefreshSprites()
    {
        suitSR.sprite = suit.sprite;
        hatSR.sprite = hat.sprite;
        weaponSR.sprite = weapon.sprite;
    }

    private void Update()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, currentHealth / maxHealth, Time.deltaTime * 5f);
        staminaBar.fillAmount = Mathf.Lerp(
            staminaBar.fillAmount, 
            currentStamina / maxStamina, 
            Time.deltaTime * 5f);
    }

    public void ChangeLife(float changeAmount)
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

    public bool canUseSkill()
    {
        return currentStamina == maxStamina;
    }

    public abstract void Heal();

    public abstract void Attack();

    public abstract void SuperAttack();

    public abstract void OnDeath();

    public abstract void OnEndTurn();
}
