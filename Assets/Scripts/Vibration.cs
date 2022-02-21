using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.NiceVibrations;

public class Vibration : MonoBehaviour
{
    public Toggle toggle;

    private void Start()
    {
        toggle.GetComponent<Toggle>();
        if (PlayerPrefs.HasKey("state"))
        {
            if (PlayerPrefs.GetInt("state") == 1)
            {
                toggle.isOn = true;
            }
            else
            {
                toggle.isOn = false;
            }
        }
    }

    private void Update()
    {
        Toggle_Changed(toggle.isOn);
    }

    public void Toggle_Changed(bool newValue)
    {
        if (newValue == true)
        {
            PlayerPrefs.SetInt("state", 1);    
            MMVibrationManager.SetHapticsActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("state", 0);
            MMVibrationManager.SetHapticsActive(false);
        }
        
        
    }
    
}
