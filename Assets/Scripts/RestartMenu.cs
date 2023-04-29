using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class RestartMenu : MonoBehaviour
{
    public GameObject normalUI;
    public GameObject restartUI;

    public GameObject shrinkUIgroup;
    public Text finalScore;

    private float finalRadius;
    private Volume volume;
    private DepthOfField dof;

    private GameManager gmRef;
    private PlanetShrink planetRef;

    private Touch touch;
    private bool restartClickedBegan;

    private void Start()
    {
        volume = FindObjectOfType<Volume>();
        volume.profile.TryGet(out dof);

        gmRef = FindObjectOfType<GameManager>();
        planetRef = FindObjectOfType<PlanetShrink>();
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
            shrinkUIgroup.transform.localScale = 1.2f * Vector3.one * planetRef.radius / planetRef.initalRadius;

            // depth of field change
            //dof.gaussianStart.value = Mathf.Lerp(dof.gaussianStart.value, 250.0f, 0.35f * Time.deltaTime);

            dof.gaussianStart.value = Mathf.Lerp(dof.gaussianStart.value, 0.0f, 0.35f * Time.deltaTime);
            dof.gaussianEnd.value = Mathf.Lerp(dof.gaussianEnd.value, 0.0f, 0.35f * Time.deltaTime);


            if (gmRef.isAndroid)
            {
                if (Input.touchCount > 0)
                {
                    touch = Input.GetTouch(0);

                    if (touch.position.y > Screen.height / 3 && touch.phase == TouchPhase.Began)
                    {
                        restartClickedBegan = true;
                    }

                    if(restartClickedBegan && touch.phase == TouchPhase.Ended)
                        gmRef.RestartGame();
                }
                else
                {
                    restartClickedBegan = false;
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
