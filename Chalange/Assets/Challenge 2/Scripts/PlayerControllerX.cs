using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool dogIsReady = true;

    // Update is called once per frame

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(1);
        dogIsReady = true;
    }
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) & dogIsReady)
        {
            dogIsReady = false;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            StartCoroutine(SpawnTimer());
        }
    }
}
