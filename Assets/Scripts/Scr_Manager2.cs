using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Scr_Manager2 : MonoBehaviour
{

    public GameObject[] obstacles;
    public GameObject[] collectables;
    public GameObject[] health;

    public float obstacleSpawnX;
    public float obstacleSpawnYMax;
    public float obstacleSpawnYMin;

    public Vector2 obstacleSpawnPos;
    public Vector2 collectableSpawnPos;
    public Vector2 healthSpawnPos;

    //public GameObject spawnedObstacle = null;
    GameObject spawnedCollectable;
    CapsuleCollider2D obCollider;

    private void Start()
    {
        // At the start, tell the program to spawn a new obstacle every 3 seconds
        InvokeRepeating("SpawnObstacle", 0f, 3f);
        InvokeRepeating("SpawnCollectable", 1f, 2f);
        InvokeRepeating("SpawnHealth", 10f, 10f);
    }


    void SpawnObstacle()
    {
        // Create the spawn position for the obstacles by using a given X-position and choose a random Y-value given a minimum and a maximum
        obstacleSpawnPos = new Vector2(obstacleSpawnX, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));

        // Create the obstacle at the new position, and name it, so we can reference it
        GameObject spawnedObstacle = Instantiate(obstacles[UnityEngine.Random.Range(0, obstacles.Length)], obstacleSpawnPos, Quaternion.identity);
        obCollider = spawnedObstacle.GetComponent<CapsuleCollider2D>();

        // Destroy the obstacle after sufficient time has passed to preserve memory
        Destroy(spawnedObstacle, 8f);
    }

    void SpawnCollectable()
    {
        // Create the spawn position for the obstacles by using a given X-position and choose a random Y-value given a minimum and a maximum
        collectableSpawnPos = new Vector2(obstacleSpawnX + 2, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));

        //GameObject spawnedCollectable;

        bool isInside = IsPointInsideCapsule(collectableSpawnPos, obCollider);

        if (!isInside)
        {
            // Create the obstacle at the new position, and name it, so we can reference it
            spawnedCollectable = Instantiate(collectables[UnityEngine.Random.Range(0, collectables.Length)], collectableSpawnPos, Quaternion.identity);
        }
        else
        {
            collectableSpawnPos = new Vector2(obstacleSpawnX, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));
            // Create the obstacle at the new position, and name it, so we can reference it
            spawnedCollectable = Instantiate(collectables[UnityEngine.Random.Range(0, collectables.Length)], collectableSpawnPos, Quaternion.identity);
        }

        // Destroy the obstacle after sufficient time has passed to preserve memory
        Destroy(spawnedCollectable, 10f);
    }

    void SpawnHealth()
    {
        // Create the spawn position for the obstacles by using a given X-position and choose a random Y-value given a minimum and a maximum
        healthSpawnPos = new Vector2(obstacleSpawnX + 1, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));

        GameObject spawnedHealth;

        if (healthSpawnPos.y != obstacleSpawnPos.y && healthSpawnPos.y != collectableSpawnPos.y)
        {
            // Create the obstacle at the new position, and name it, so we can reference it
            spawnedHealth = Instantiate(health[UnityEngine.Random.Range(0, health.Length)], healthSpawnPos, Quaternion.identity);
        }
        else
        {
            healthSpawnPos = new Vector2(obstacleSpawnX, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));
            // Create the obstacle at the new position, and name it, so we can reference it
            spawnedHealth = Instantiate(collectables[UnityEngine.Random.Range(0, health.Length)], healthSpawnPos, Quaternion.identity);
        }


        // Destroy the obstacle after sufficient time has passed to preserve memory
        Destroy(spawnedHealth, 10f);
    }

    public bool IsPointInsideCapsule(Vector2 point, CapsuleCollider2D capCol)
    {
        Vector2 closestPoint = capCol.ClosestPoint(point);
        return Vector2.Distance(point, closestPoint) < 0.001f; // Tolerance for floating-point precision
    }
}
