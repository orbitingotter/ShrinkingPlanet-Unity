using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSway : MonoBehaviour
{
    private Vector3 newPosition;
    private Quaternion newRotation;

    public float lerpSpeed = 0.1f;
    public float randomRange = 0.05f;
    void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
    }
    void Update()
    {
        GenerateNewPositions();
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * lerpSpeed * 2000);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * lerpSpeed);
    }

    void GenerateNewPositions()
    {
        newPosition += new Vector3(Random.Range(-randomRange, +randomRange), Random.Range(-randomRange, +randomRange), Random.Range(-randomRange, +randomRange));
        newRotation = newRotation * Quaternion.Euler(Random.Range(-randomRange, +randomRange), Random.Range(-randomRange, +randomRange), Random.Range(-randomRange, +randomRange));// * Quaternion.LookRotation(new Vector3(0, 0, 0), Vector3.up);
    }
}
