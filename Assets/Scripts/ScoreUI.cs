using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreUI : MonoBehaviour
{
    public Text score;
    void Update()
    {
        score.text = FindObjectOfType<GameManager>().radius.ToString("0.0");
    }
}
