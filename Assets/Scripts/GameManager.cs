using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float radius { get; set; } = 50.0f;
    public float shrinkRate = 0.001f;
    public void EndGame()
    {
        if(!gameHasEnded)
        {
            gameHasEnded = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Update()
    {
        radius -= shrinkRate;
    }
}
