using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraterSpawner : MonoBehaviour
{
    public GameObject craterPrefab;
    public GameObject explosionPrefab;

    public void SpawnCrater(Transform meteorTransform)
    {
        Instantiate(explosionPrefab, meteorTransform.position, meteorTransform.rotation, transform);
        Instantiate(craterPrefab, meteorTransform.position, meteorTransform.rotation, transform);
    }
}
