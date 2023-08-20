using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateManager : MonoBehaviour
{
    // GAME OBJECTS:
    public GameObject buttonsCanvas;
    public GameObject selectSkillCanvas;

    private void Start()
    {
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
}

