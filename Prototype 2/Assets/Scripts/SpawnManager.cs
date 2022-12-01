using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] animalPrefaps;
    protected float spawnRangeX = 10;
    protected float spawnPosZ = 29;

    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefaps.Length);
        Vector3 spawnpos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefaps[animalIndex], spawnpos, animalPrefaps[animalIndex].transform.rotation);
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
