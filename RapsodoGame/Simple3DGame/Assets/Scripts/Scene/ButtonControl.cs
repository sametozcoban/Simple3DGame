using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    [SerializeField] private GameObject settingsUI;
    [SerializeField] private Button[] mainMenuButtons;

    private void Start()
    {
        settingsUI.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
   
    public void Settings()
    {
        foreach (var button in mainMenuButtons)
        {
            button.gameObject.SetActive(false);
        }
        settingsUI.SetActive(true);
    }

    public void CloseSettingsButton()
    {
        foreach (var button in mainMenuButtons)
        {
            button.gameObject.SetActive(true);
        }
        settingsUI.SetActive(false);
    }
}
