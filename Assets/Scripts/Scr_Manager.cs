using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;

public class Scr_Manager : MonoBehaviour
{
    public Scr_Distance GameTime;

    public GameObject[] obstacles;
    public GameObject[] collectables;
    public GameObject[] health;

    public float obstacleSpawnX;
    public float obstacleSpawnYMax;
    public float obstacleSpawnYMin;

    //public Vector2 obstacleSpawnPos;
    private bool spawnHealth = false;
    public float spawnSpeed = 1f;

    //GameObject spawnedObstacle;

    private void Start()
    {
        // Start the timer to keep track of when to spawn a time increaser
        StartCoroutine(WaitForSecondsCoroutine());

        // At the start, tell the program to spawn a new obstacle every 1 seconds
        //InvokeRepeating("pickArray", 0f, spawnSpeed);
        StartCoroutine("RepeatSpawn");
    }

    private void Update()
    {
        CheckTime();
    }

    void pickArray()
    {
        // Randomly choose one of the three arrays
        int randomIndex = UnityEngine.Random.Range(0, 2);

        if (spawnHealth)
        {
            // Spawn an object from the health array
            SpawnObject(health);

            // Reset the health timer
            spawnHealth = false;
            StartCoroutine(WaitForSecondsCoroutine());
        }
        else if (randomIndex == 0)
        {
            // Spawn an object from the obstacles array
            SpawnObject(obstacles);
        }
        else if (randomIndex >= 1)
        {
            // Spawn an object from the collectables array
            SpawnObject(collectables);
        }
        else
        {
            Debug.LogError("Invalid random index!");
        }
}



    void SpawnObject(GameObject[] array)
    {
        // Create the spawn position for the obstacles by using a given X-position and choose a random Y-value given a minimum and a maximum
        Vector2 obstacleSpawnPos = new Vector2(obstacleSpawnX, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));

        // Create the obstacle at the new position, and name it, so we can reference it
        GameObject spawnedObstacle = Instantiate(array[UnityEngine.Random.Range(0, array.Length)], obstacleSpawnPos, Quaternion.identity);

        // Destroy the obstacle after sufficient time has passed to preserve memory
        Destroy(spawnedObstacle, 8f);
    }




    // Couroutine to track when 10 seconds has passed
    private IEnumerator WaitForSecondsCoroutine()
    {
        yield return new WaitForSeconds(8f);
        spawnHealth = true;
    }


    private void CheckTime()
    {
        if (GameTime.totalGameTime < 15)
        {
            // Add condition
        }
        else if (GameTime.totalGameTime < 30)
        {
            spawnSpeed = 0.98f;
        }
        else if (GameTime.totalGameTime < 45)
        {
            spawnSpeed = 0.96f;
        }
        else if (GameTime.totalGameTime < 60)
        {
            spawnSpeed = 0.94f;
        }
        else if (GameTime.totalGameTime < 75)
        {
            spawnSpeed = 0.92f;
        }
        else if (GameTime.totalGameTime < 90)
        {
            spawnSpeed = 0.90f;
        }
        else if (GameTime.totalGameTime < 105)
        {
            spawnSpeed = 0.88f;
        }
        else if (GameTime.totalGameTime < 145)
        {
            spawnSpeed = 0.86f;
        }
        else if (GameTime.totalGameTime > 200)
        {
            spawnSpeed = 0.84f;
        }
    }

    private IEnumerator RepeatSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnSpeed);
            pickArray();
        }
    }
}






/*

void SpawnObstacle()
{
    // Create the spawn position for the obstacles by using a given X-position and choose a random Y-value given a minimum and a maximum
    obstacleSpawnPos = new Vector2(obstacleSpawnX, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));

    // Create the obstacle at the new position, and name it, so we can reference it
    spawnedObstacle = Instantiate(obstacles[UnityEngine.Random.Range(0, obstacles.Length)], obstacleSpawnPos, Quaternion.identity);

    // Destroy the obstacle after sufficient time has passed to preserve memory
    Destroy(spawnedObstacle, 8f);
}

void SpawnCollectable()
{
    // Create the spawn position for the obstacles by using a given X-position and choose a random Y-value given a minimum and a maximum
    collectableSpawnPos = new Vector2(obstacleSpawnX + 2, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));

    // Create the obstacle at the new position, and name it, so we can reference it
    spawnedCollectable = Instantiate(collectables[UnityEngine.Random.Range(0, collectables.Length)], collectableSpawnPos, Quaternion.identity);

    // Destroy the obstacle after sufficient time has passed to preserve memory
    Destroy(spawnedCollectable, 10f);
}

void SpawnHealth()
{
    // Create the spawn position for the obstacles by using a given X-position and choose a random Y-value given a minimum and a maximum
    healthSpawnPos = new Vector2(obstacleSpawnX + 1, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));

    // Create the obstacle at the new position, and name it, so we can reference it
    spawnedHealth = Instantiate(health[UnityEngine.Random.Range(0, health.Length)], healthSpawnPos, Quaternion.identity);

    // Destroy the obstacle after sufficient time has passed to preserve memory
    Destroy(spawnedHealth, 10f);
}

*/