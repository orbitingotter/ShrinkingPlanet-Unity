using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;



public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;

    public bool isAndroid = false;

    public static GameManager instance;

    // settings scene to scene
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

        ChangeQuality();
    }

    public void ChangeQuality()
    {
        // Low
        if (QualitySettings.GetQualityLevel() == 0)
        {
            bloom.active = false;
            dof.active = false;
            vignette.active = false;
        }
        // Medium
        if (QualitySettings.GetQualityLevel() == 1)
        {
            bloom.active = true;
            dof.active = true;
            vignette.active = false;
        }
        // High
        if (QualitySettings.GetQualityLevel() == 2)
        {
            bloom.active = true;
            dof.active = true;
            vignette.active = true;
        }
    }

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
