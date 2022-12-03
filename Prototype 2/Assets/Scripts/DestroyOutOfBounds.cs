using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float forwardBound = PlayAreaLimits.forward + 1;
    private float backBound = PlayAreaLimits.back - 1;
    private float rightBound = PlayAreaLimits.right + 1;
    private float leftBound = PlayAreaLimits.left - 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > forwardBound
        || transform.position.z < backBound
        || transform.position.x > rightBound
        || transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
        // else if (transform.position.z < backBound)
        // {
        //     // Debug.Log("Game Over!");
        //     Destroy(gameObject);
        // }
    }
}
