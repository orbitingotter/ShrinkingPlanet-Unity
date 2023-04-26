using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHit : MonoBehaviour
{
    CraterSpawner craterRef;

    void Start()
    {
        craterRef = FindObjectOfType<CraterSpawner>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Planet" || collision.collider.name == "Player" || collision.collider.tag == "Crater")
        {
            craterRef.SpawnCrater(transform);
            Destroy(gameObject);
        }
    }
}
