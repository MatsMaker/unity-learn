using UnityEngine;
using System.Collections;
public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    // private float startDelay = 1.0f;
    // private float spawnInterval = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
        StartCoroutine(StartRepeat());
    }

    IEnumerator StartRepeat()
    {
        yield return new WaitForSeconds(Random.Range(3, 5));
        SpawnRandomBall();
        StartCoroutine(StartRepeat());
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        int animalIndex = Random.Range(0, ballPrefabs.Length);
        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[animalIndex], spawnPos, ballPrefabs[animalIndex].transform.rotation);
    }

}
