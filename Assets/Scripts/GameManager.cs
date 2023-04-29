using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.Rendering.PostProcessing;



public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;

    public bool isAndroid = false;

    public static GameManager instance;

    //// settings scene to scene
    //private Bloom bloom;
    //private DepthOfField dof;
    //private MotionBlur motionBlur;
    //private Vignette vignette;

    void Start()
    {
        ChangeQuality();
    }

    public void ChangeQuality()
    {
        //Camera.main.GetComponent<PostProcessVolume>().profile.TryGetSettings(out bloom);
        //Camera.main.GetComponent<PostProcessVolume>().profile.TryGetSettings(out dof);
        //Camera.main.GetComponent<PostProcessVolume>().profile.TryGetSettings(out motionBlur);
        //Camera.main.GetComponent<PostProcessVolume>().profile.TryGetSettings(out vignette);
        //// Low
        //if (QualitySettings.GetQualityLevel() == 0)
        //{
        //    bloom.active = false;
        //    dof.active = false;
        //    motionBlur.active = false;
        //    vignette.active = false;
        //}
        //// Medium
        //if (QualitySettings.GetQualityLevel() == 1)
        //{
        //    bloom.active = true;
        //    dof.active = true;
        //    motionBlur.active = true;
        //    vignette.active = false;
        //}
        //// High
        //if (QualitySettings.GetQualityLevel() == 2)
        //{
        //    bloom.active = true;
        //    dof.active = true;
        //    motionBlur.active = true;
        //    vignette.active = true;
        //}
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
