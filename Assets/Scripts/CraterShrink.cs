using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraterShrink : MonoBehaviour
{
    private PlanetShrink planetRef;

    void Start()
    {
        planetRef = FindObjectOfType<PlanetShrink>();
    }
    void Update()
    {
        transform.localScale = Vector3.one * planetRef.radius / planetRef.initalRadius;
    }
}
