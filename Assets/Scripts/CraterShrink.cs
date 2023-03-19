using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraterShrink : MonoBehaviour
{
    void Update()
    {
        transform.localScale = Vector3.one * (FindObjectOfType<PlanetShrink>().radius / FindObjectOfType<PlanetShrink>().initalRadius);
    }
}
