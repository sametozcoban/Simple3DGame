using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 3;

    public SliderControl _sliderControl;
    private void Start()
    {
        _sliderControl.SetMaxValue(playerHealth);
    }

    private void Update()
    {
        HealthControl();
        _sliderControl.SetHealth(playerHealth);

    }

    void HealthControl() 
    {
        if (playerHealth < 1)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
