using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    public GravityAttractor attractor;

    void Start()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        attractor = FindObjectOfType<GravityAttractor>();
    }


    void Update()
    {
        attractor.Attract(transform);
    }
}
