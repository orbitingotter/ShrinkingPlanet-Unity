using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class RestartMenu : MonoBehaviour
{
    public GameObject normalUI;
    public GameObject restartUI;

    public GameObject shrinkUIgroup;
    public Text finalScore;

    private float finalRadius;
    private DepthOfField dof;

    private GameManager gmRef;

    private void Start()
    {
        gmRef = FindObjectOfType<GameManager>();
    }
    public void ShowMenu()
    {
        normalUI.SetActive(false);
        restartUI.SetActive(true);

        // record final score
        finalRadius = FindObjectOfType<PlanetShrink>().radius;
        finalScore.text = "d = " + finalRadius.ToString("0.0") + "m";

        // change font color based on headlights
        if (FindObjectOfType<CarHeadlights>().headlightOn)
        {
            for (int i = 0; i < shrinkUIgroup.transform.childCount; i++)
            {
                shrinkUIgroup.transform.GetChild(i).GetComponent<Text>().color = new Color(205, 205, 205);
            }
            GameObject.Find("RestartUI/ExitButton").GetComponentInChildren<Text>().color = new Color(205, 205, 205);
        }
    }

    private void Update()
    {
        if (gmRef.gameHasEnded)
        {
            // shrink UI with planet
            shrinkUIgroup.transform.localScale = 1.2f * Vector3.one * FindObjectOfType<PlanetShrink>().radius / FindObjectOfType<PlanetShrink>().initalRadius;

            // depth of field change
            Camera.main.GetComponent<PostProcessVolume>().profile.TryGetSettings(out dof);
            dof.focalLength.value = Mathf.Lerp(dof.focalLength.value, 120.0f, 0.3f * Time.deltaTime);


            if(gmRef.isAndroid)
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    if (touch.position.x > Screen.height / 10)
                        gmRef.RestartGame();
                }
            }
            else
            {
                // Keyboard input
                if (Input.GetKey(KeyCode.Space))
                {
                    gmRef.RestartGame();
                }

                if (Input.GetKey(KeyCode.Escape))
                {
                    gmRef.StartMainMenu();
                }
            }
        }
    }
}
