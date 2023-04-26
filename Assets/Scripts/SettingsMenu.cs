using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Rendering.PostProcessing;


public class SettingsMenu : MonoBehaviour
{
    public Font normalFont;
    public Font highlightFont;

    public Text lowText;
    public Text mediumText;
    public Text highText;

    public AudioMixer mixer;

    // settings var
    private Bloom bloom;
    private DepthOfField dof;
    private MotionBlur motionBlur;
    private Vignette vignette;

    void Start()
    {
        UpdateQuality();
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        UpdateQuality();
    }

    void UpdateQuality()
    {
        Debug.Log(QualitySettings.GetQualityLevel());
        lowText.font = normalFont;
        mediumText.font = normalFont;
        highText.font = normalFont;

        Camera.main.GetComponent<PostProcessVolume>().profile.TryGetSettings(out bloom);
        Camera.main.GetComponent<PostProcessVolume>().profile.TryGetSettings(out dof);
        Camera.main.GetComponent<PostProcessVolume>().profile.TryGetSettings(out motionBlur);
        Camera.main.GetComponent<PostProcessVolume>().profile.TryGetSettings(out vignette);


        // Low
        if (QualitySettings.GetQualityLevel() == 0)
        {
            lowText.font = highlightFont;

            bloom.active = false;
            dof.active = false;
            motionBlur.active = false;
            vignette.active = false;
        }
        // Medium
        if (QualitySettings.GetQualityLevel() == 1)
        {
            mediumText.font = highlightFont;

            bloom.active = true;
            dof.active = true;
            motionBlur.active = true;
            vignette.active = false;
        }
        // High
        if (QualitySettings.GetQualityLevel() == 2)
        {
            highText.font = highlightFont;

            bloom.active = true;
            dof.active = true;
            motionBlur.active = true;
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
