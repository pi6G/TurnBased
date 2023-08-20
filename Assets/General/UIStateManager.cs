using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

public class UIStateManager : MonoBehaviour
{
    // PRECISION BAR
    [SerializeField] private GameObject precisionBarPrefab;
    [SerializeField] private float precisionBarDespawnSeconds;
    private PrecisionBar precisionBar;

    // UI ELEMENTS
    [SerializeField] private GameObject buttonsCanvas;
    [SerializeField] private GameObject selectSkillCanvas;

    // SCENE OBJECTS
    private Player player;
    private Enemy enemy;

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

    public void OnAttackExecution(float precision)
    {
        Debug.Log("Precision Percentage: " + precision);
        player.DealDamage(precision * 10);
        StartCoroutine(DestroyPrecisionBar());
    }

    public IEnumerator DestroyPrecisionBar()
    {
        yield return new WaitForSeconds(precisionBarDespawnSeconds);
        Destroy(precisionBar.gameObject);

        buttonsCanvas.SetActive(true);
    }
}