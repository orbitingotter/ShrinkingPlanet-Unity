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

    void Update()
    {
        Vector3 lightPos = light.transform.position - 100.0f * light.transform.forward; // moving light far away from origin

        Vector3 playerToLight = lightPos - player.transform.position;
        float distance = playerToLight.magnitude;
        Vector3 origin = player.transform.position;
        Vector3 direction = playerToLight.normalized;


        if (Physics.Raycast(origin, direction, distance))
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
