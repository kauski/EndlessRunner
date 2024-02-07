using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject destroyablePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private Vector3 spawnPos2 = new Vector3(25, 1, 0);
    public float spawnTime = 2.0f;
    public float startTime = 2.0f;
    private PlayerController playerController;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startTime, spawnTime);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

  
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        if (playerController.gameOver == false)
        {
            int rand = Random.Range(0, 2);
            if (rand > 0)
            {
                Instantiate(destroyablePrefab, spawnPos, destroyablePrefab.transform.rotation);
            }
            else
            {

            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
            int randomi = Random.Range(0, 2);
            if (randomi > 0)
            {
                Instantiate(obstaclePrefab, spawnPos2, obstaclePrefab.transform.rotation);
            }
        }
        }
    }
}
