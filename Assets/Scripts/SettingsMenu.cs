using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Font normalFont;
    public Font highlightFont;

    public Text lowText;
    public Text mediumText;
    public Text highText;

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
}
