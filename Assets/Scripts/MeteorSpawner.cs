using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;

    public float spawnRate = 1.0f;
    public float distance = 150.0f;
    public int maxCraterCount = 50;

    void Start()
    {
        StartCoroutine(SpawnMeteor());
    }

    IEnumerator SpawnMeteor()
    {
        Vector3 meteorPos = Random.onUnitSphere * distance;
        Instantiate(meteorPrefab, meteorPos, Quaternion.LookRotation(meteorPos), transform);

        yield return new WaitForSeconds(spawnRate);

        // Limit total crater count
        if (FindObjectOfType<CraterSpawner>().transform.childCount > maxCraterCount * 2)
            spawnRate = float.MaxValue;

        StartCoroutine(SpawnMeteor());
    }
}
