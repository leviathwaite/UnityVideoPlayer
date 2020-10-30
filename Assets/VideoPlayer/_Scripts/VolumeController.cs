using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

// Controls volume via slider and mixer
// Saves volume level to PlayerPrefs and loads on appllication start
public class VolumeController : MonoBehaviour
{
    public AudioMixer _audioMixer;
   

    [SerializeField]
    private string masterVolumeName = "MasterVolume";
    [SerializeField]
    private bool isMuted = false;
    
    

    private Slider _slider;
    private float zero = 0.0000001f;
    private float currentVol;
    private string prefsVolumeLevelString = "VolumeLevel";

    private void Start()
    {
        _slider = GetComponent<Slider>();

        // TODO Saving and Loading not working
        currentVol = PlayerPrefs.GetFloat(prefsVolumeLevelString, 0.5f);
        _slider.value = currentVol;
        SetVolumeLevel(currentVol);
    }

    public void SetVolumeLevel(float sliderValue)
    {
        _audioMixer.SetFloat(masterVolumeName, Mathf.Log10(sliderValue) * 20);
        SaveVolumeLevel();
    }

    public void SetMuted(bool value)
    {
        // TODO remove
        Debug.Log("isMuted = " + value.ToString());

        isMuted = value;
        // muted
        if(isMuted)
        {
            // store current volume level
            currentVol = _slider.value;

            SetVolumeLevel(zero);
            _slider.value = zero;
        }
        // Not muted
        else
        {
            SetVolumeLevel(currentVol);
            _slider.value = currentVol;
        }

        
    }

    private void SaveVolumeLevel()
    {
        currentVol = _slider.value;
        Debug.Log("Current Volume = " + currentVol);
        PlayerPrefs.SetFloat(prefsVolumeLevelString, currentVol);
    }
}
