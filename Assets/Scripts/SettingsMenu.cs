using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public Font normalFont;
    public Font highlightFont;

    public Text lowText;
    public Text mediumText;
    public Text highText;

    public AudioMixer mixer;

    void Start()
    {
        UpdateFont();
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        UpdateFont();
    }

    void UpdateFont()
    {
        lowText.font = normalFont;
        mediumText.font = normalFont;
        highText.font = normalFont;

        // Low
        if (QualitySettings.GetQualityLevel() == 1)
        {
            lowText.font = highlightFont;
        }
        // Medium
        if (QualitySettings.GetQualityLevel() == 3)
        {
            mediumText.font = highlightFont;
        }
        // High
        if (QualitySettings.GetQualityLevel() == 5)
        {
            highText.font = highlightFont;
        }
    }

    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20 );
    }
}
