using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Lives = 3;
    public int Score = 0;
    public GameObject projectilePrefab;
    public float horizontalInput;
    public float forwardInput;
    public float speed = 15f;
    private float xRange = 20f;
    private float zRange = 10f;
    // Start is called before the first frame update
    void Start()
    {
        ShowState();
    }

    bool IsLive()
    {
        return Lives > 0;
    }

    void ShowState()
    {
        Debug.Log("Lives: " + Lives + " Score: " + Score);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }


        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * speed);

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f), projectilePrefab.transform.rotation);
        }
    }

    public void hit()
    {
        Lives--;
        ShowState();
        ifDied();
    }

    protected void ifDied()
    {
        if (!IsLive())
        {
            Debug.Log("=== Game Over! ===" + "Score: " + Score);
            Destroy(gameObject);
        }
    } 

    void OnTriggerEnter(Collider other)
    {
        hit();
    }
}
