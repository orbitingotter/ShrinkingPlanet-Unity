using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreUI : MonoBehaviour
{
    public Text score;

    private PlanetShrink planetRef;
    private string scorePrefix = "d = ";
    private string scoreSuffix = "m";

    void Start()
    {
        planetRef = FindObjectOfType<PlanetShrink>();
    }
    void Update()
    {
        score.text = scorePrefix + planetRef.radius.ToString("0.0") + scoreSuffix;
    }
}
