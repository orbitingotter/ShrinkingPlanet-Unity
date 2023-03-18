using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraterSpawner : MonoBehaviour
{
    public GameObject craterPrefab;
    public void SpawnCrater(Transform meteorTransform)
    {
        Instantiate(craterPrefab, meteorTransform.position, meteorTransform.rotation, transform);
    }
}
