using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Planet" || collision.collider.name == "Player" || collision.collider.tag == "Crater")
        {
            FindObjectOfType<CraterSpawner>().SpawnCrater(transform);
            Destroy(gameObject);
        }
    }
}
