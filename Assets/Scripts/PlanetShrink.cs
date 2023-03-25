using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetShrink : MonoBehaviour
{
    public float radius { get; set; }
    public float initalRadius { get; } = 50.0f;
    public float shrinkRate;


    void Start()
    {
        radius = initalRadius;
    }


    void Update()
    {
        radius -= shrinkRate * Time.deltaTime;

        // todo : radius zero
        //if (radius == 0.0f)
            //Debug.Log("End Game");
        transform.localScale = Vector3.one * radius;
    }
}
