using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] animalPrefabs;
    protected Vector3[] spawnTypes = {Vector3.left, Vector3.forward, Vector3.right};
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    void SpawnRandomAnimal()
    {
        Vector3 spawnType = spawnTypes[Random.Range(0, spawnTypes.Length)];
        Vector3 spawnPos = SpawnPosition(spawnType);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Quaternion rotation = SpawnRotation(animalPrefabs[animalIndex], spawnType);
        Instantiate(animalPrefabs[animalIndex], spawnPos, rotation);
    }

    Quaternion SpawnRotation(GameObject prefab, Vector3 direction)
    {
        if (direction == Vector3.left)
        {
            return Quaternion.Euler(Vector3.up * 90);
        }
        if (direction == Vector3.right)
        {
            return Quaternion.Euler(Vector3.up * -90);
        }
        // is equal Vector3.froward
        return Quaternion.Euler(Vector3.up * 180);
    }

    Vector3 SpawnPosition(Vector3 direction)
    {
        if (direction == Vector3.left)
        {
            return new Vector3(PlayAreaLimits.left, 0, Random.Range(PlayAreaLimits.back, PlayAreaLimits.forward));
        }
        if (direction == Vector3.right)
        {
            return new Vector3(PlayAreaLimits.right, 0, Random.Range(PlayAreaLimits.back, PlayAreaLimits.forward));
        }
        // is equal Vector3.froward
        return new Vector3(Random.Range(PlayAreaLimits.left, PlayAreaLimits.right), 0, PlayAreaLimits.forward);
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomAnimal();
        }
    }
}
