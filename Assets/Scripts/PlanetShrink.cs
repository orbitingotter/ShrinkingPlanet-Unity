using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetShrink : MonoBehaviour
{
    public float radius { get; set; }
    public float initalRadius { get; } = 50.0f;
    public float shrinkRate;
    public float endRadius;

    void Start()
    {
        radius = initalRadius;
    }


    void Update()
    {
        if (radius > endRadius)
            radius -= shrinkRate * Time.deltaTime;
;
        transform.localScale = Vector3.one * radius;
    }
}
