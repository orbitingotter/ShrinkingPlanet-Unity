using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            FindObjectOfType<RestartMenu>().ShowMenu();
            FindObjectOfType<CarCollide>().DestroyCar();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    // CREDITS
    public void OpenGithub()
    {
        Application.OpenURL("https://github.com/orbitingotter/ShrinkingPlanet-Unity");
    }
}
