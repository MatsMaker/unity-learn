using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private GameController gameController;
    private float forwardBound = PlayAreaLimits.forward + 1;
    private float backBound = PlayAreaLimits.back - 1;
    private float rightBound = PlayAreaLimits.right + 1;
    private float leftBound = PlayAreaLimits.left - 1;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObj = GameObject.Find("GameController");
        gameController = gameControllerObj.GetComponent(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > forwardBound
        || transform.position.z < backBound
        || transform.position.x > rightBound
        || transform.position.x < leftBound)
        {
            if (gameObject.tag == "Animal") {
                Debug.Log("Animal is out");
                gameController.playerHit();
            }
            Destroy(gameObject);
        }
    }
}
