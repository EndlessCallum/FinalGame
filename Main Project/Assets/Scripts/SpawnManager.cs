using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    // Spawn Bullet
    public GameObject bullet;
    private float startDelay = 5.0f;
    private float spawnInterval = 1.0f;
    private float spawnPosX = 6.3f;
    private float spawnPosY = 0.6f;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        InvokeRepeating("SpawnBullet", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnBullet()
    {
        if (gameManager.isGameActive == true)
        {
        Vector3 spawnPos = new Vector3(-spawnPosX, spawnPosY, Random.Range(55, 67));

        Instantiate(bullet, spawnPos, bullet.transform.rotation);
        }
    }
}
