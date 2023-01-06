using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = Instantiate(playerPrefab, playerPrefab.transform.position, playerPrefab.transform.rotation);
        playerController =  player.GetComponent(typeof(PlayerController)) as PlayerController;
    }

    public void playerHit()
    {
        if (playerController) {
            playerController.hit();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
