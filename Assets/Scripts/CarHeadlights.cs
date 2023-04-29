using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHeadlights : MonoBehaviour
{
    public bool headlightOn = false;

    public GameObject light;
    public GameObject player;

    public GameObject headlight1;
    public GameObject headlight2;

    private Vector3 lightPos;
    private Vector3 playerToLight;


    void Update()
    {
        lightPos = light.transform.position - 100.0f * light.transform.forward; // moving light far away from origin

        playerToLight = lightPos - player.transform.position;


        if (Physics.Raycast(player.transform.position, playerToLight.normalized, playerToLight.magnitude))
        {
            headlightOn = true;
        }
        else
        {
            headlightOn = false;
        }

        headlight1.SetActive(headlightOn);
        headlight2.SetActive(headlightOn);
    }
}
