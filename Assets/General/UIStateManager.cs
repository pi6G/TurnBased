using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStateManager : MonoBehaviour
{
    // PRECISION BAR
    [SerializeField] private GameObject precisionBarPrefab;
    [SerializeField] private float precisionBarDespawnSeconds;
    private PrecisionBar precisionBar;

    // UI ELEMENTS
    [SerializeField] private GameObject buttonsCanvas;
    [SerializeField] private GameObject shopCanvas;
    [SerializeField] private GameObject selectSkillCanvas;
    [SerializeField] private Button AttackButton;

    [SerializeField] private Button SkillButton;


    [SerializeField] private TMP_Text coins;

    // SCENE OBJECTS
    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    public void UpdateCoins()
    {
        coins.text = Shop.money.ToString();
    }

    public void OnSkillButton()
    {
        buttonsCanvas.SetActive(false);
        selectSkillCanvas.SetActive(true);
    }

    public void OnCancelSkillButton()
    {
        buttonsCanvas.SetActive(true);
        selectSkillCanvas.SetActive(false);
    }

    public void OnAttack()
    {
        buttonsCanvas.SetActive(false);

        PrecisionBar.difficulty = player.weapon.attackDifficulty;
        precisionBar = Instantiate(precisionBarPrefab).GetComponent<PrecisionBar>();
        precisionBar.executedAction += OnAttackExecution;
    }

    public void OnAttackExecution()
    {
        AttackButton.interactable = false;

        player.Attack();

        StartCoroutine(DestroyPrecisionBar());
    }
    public void OnHeal()
    {
        selectSkillCanvas.SetActive(false);

        PrecisionBar.difficulty = player.suit.healingDifficulty;
        precisionBar = Instantiate(precisionBarPrefab).GetComponent<PrecisionBar>();
        precisionBar.executedAction += OnHealExecution;
    }

    public void OnHealExecution()
    {
        SkillButton.interactable = false;

        player.Heal();

        StartCoroutine(DestroyPrecisionBar());
    }

    public void OnSuperAttack()
    {
        selectSkillCanvas.SetActive(false);

        PrecisionBar.difficulty = player.hat.skillDifficulty;
        precisionBar = Instantiate(precisionBarPrefab).GetComponent<PrecisionBar>();
        precisionBar.executedAction += OnSuperAttackExecution;
    }

    public void OnSuperAttackExecution()
    {
        SkillButton.interactable = false;

        player.SuperAttack();

        StartCoroutine(DestroyPrecisionBar());
    }

    public IEnumerator DestroyPrecisionBar()
    {
        yield return new WaitForSeconds(precisionBarDespawnSeconds);
        Destroy(precisionBar.gameObject);

        buttonsCanvas.SetActive(true);
    }

    public void OnEndTurn()
    {
        AttackButton.interactable = true;

        player.OnEndTurn();
        if (player.canUseSkill()) SkillButton.interactable = true;

        GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>().OnEndTurn();
    }

    public void OnShopEnter()
    {
        buttonsCanvas.SetActive(false);
        shopCanvas.SetActive(true);

        shopCanvas.GetComponent<Shop>().onShopEnter();
    }

    public void OnShopExit()
    {
        buttonsCanvas.SetActive(true);
        shopCanvas.SetActive(false);
    }

    public void OnWin()
    {
        Debug.Log("Yaay, ganaste!");
    }
}