using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class SettingsMenu : MonoBehaviour
{
    public Font normalFont;
    public Font highlightFont;

    public Text lowText;
    public Text mediumText;
    public Text highText;

    public AudioMixer mixer;

    // settings var
    private Volume volume;
    private Vignette vignette;
    private Bloom bloom;
    private DepthOfField dof;

    void Start()
    {
        volume = FindObjectOfType<Volume>();
        volume.profile.TryGet(out vignette);
        volume.profile.TryGet(out bloom);
        volume.profile.TryGet(out dof);


        UpdateQuality();
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        UpdateQuality();
    }

    void UpdateQuality()
    {
        lowText.font = normalFont;
        mediumText.font = normalFont;
        highText.font = normalFont;


        // Low
        if (QualitySettings.GetQualityLevel() == 0)
        {
            lowText.font = highlightFont;

            bloom.active = false;
            dof.active = false;
            vignette.active = false;
        }
        // Medium
        if (QualitySettings.GetQualityLevel() == 1)
        {
            mediumText.font = highlightFont;

            bloom.active = true;
            dof.active = true;
            vignette.active = false;
        }
        // High
        if (QualitySettings.GetQualityLevel() == 2)
        {
            highText.font = highlightFont;

            bloom.active = true;
            dof.active = true;
            vignette.active = true;
        }
    }

    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }
}
