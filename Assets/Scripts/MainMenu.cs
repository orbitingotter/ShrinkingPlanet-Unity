using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    // Exit States
    [Header("Exit Variables")]
    public Color targetSkyColor;
    public Light directionalLight;
    public float lerpSpeed;
    public float intensityDecrement;
    private bool exit = false;
    private float endTime;


    // PLAY
    public void PlayGame()
    {
        StartCoroutine(PlayRoutine());
    }

    IEnumerator PlayRoutine()
    {
        yield return new WaitForSeconds(0.83f);
        FindObjectOfType<GameManager>().StartGame();
    }


    // EXIT
    public void ExitGame()
    {
        exit = true;
        endTime = Time.time;
    }

    private void ExitRoutine()
    {
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, targetSkyColor, lerpSpeed);
        directionalLight.intensity -= intensityDecrement;

        if (Time.time - endTime > 2.0f)
        {
            Debug.Log("QUIT");
            Application.Quit();
        }
    }

    private void Update()
    {
        if (exit)
        {
            ExitRoutine();
        }
    }
}
