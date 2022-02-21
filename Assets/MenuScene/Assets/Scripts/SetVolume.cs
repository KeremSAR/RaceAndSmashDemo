using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{

    public AudioMixer mixer2;
    public AudioMixer mixer;
    public Slider slider;
    public Slider slider2;


    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        slider2.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
    }

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);

    }

    public void SetLevel2(float sliderValue2)
    {
        mixer2.SetFloat("SFXVol", Mathf.Log10(sliderValue2) * 20);
        PlayerPrefs.SetFloat("SFXVolume", sliderValue2);
    }

}