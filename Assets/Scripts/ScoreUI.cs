using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreUI : MonoBehaviour
{
    public Text score;
    void Update()
    {
        score.text = FindObjectOfType<PlanetShrink>().radius.ToString("0.0");
    }
}
