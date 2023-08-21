using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    [SerializeField] private GameObject selectSkillCanvas;
    [SerializeField] private Button AttackButton;

    [SerializeField] private Button SkillButton;

    // SCENE OBJECTS
    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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

        precisionBar = Instantiate(precisionBarPrefab).GetComponent<PrecisionBar>();
        precisionBar.executedAction += OnHealExecution;
    }

    public void OnHealExecution()
    {
        SkillButton.interactable = false;

        player.Heal();

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
        SkillButton.interactable = true;
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>().Attack();
    }

    public void CheckStamina()
    {

    }

    public void OnWin()
    {
        Debug.Log("Yaay, ganaste!");
    }
    
}