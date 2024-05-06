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


    private bool spawnHealth = false;
    public float spawnSpeed = 1f;


    // Variables for dynamic linear speed control
    public float spawnChangeRate = -0.002f;
    public float initialSpawnRate = 1f;
    // First maxSpawnSpeed was set to 0.75
    // Second maxSpawnSpeed was set to 0.50
    public float maxSpawnSpeed = 0.50f;


    private void Start()
    {
        // Start the timer to keep track of when to spawn a time increaser
        StartCoroutine(WaitForSecondsCoroutine());

        // At the start, tell the program to spawn a new obstacle every 1 seconds
        //InvokeRepeating("pickArray", 0f, spawnSpeed);
        StartCoroutine("RepeatSpawn");

        // Linear speed control set the spawn rate to the initial rate
        spawnSpeed = initialSpawnRate;
        spawnChangeRate = -0.002f;
        maxSpawnSpeed = 0.50f;
    }

    private void Update()
    {
        // Speed control using linear function
        //spawnSpeed = -0.002f * GameTime.totalGameTime + 1.2f;
        if (spawnSpeed > maxSpawnSpeed)
        {
            spawnSpeed = spawnChangeRate * GameTime.totalGameTime + 1.2f;
            //Debug.Log("Changing speed");
        }
        else
        {
            spawnSpeed = maxSpawnSpeed;
        }
        //Debug.Log(spawnSpeed);
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
        // This causes obstacles to disapeer prematurely on slower devices.  It was replaced with a collision based alternative in a separate script
        //Destroy(spawnedObstacle, 8f);
    }




    // Couroutine to track when 10 seconds has passed
    private IEnumerator WaitForSecondsCoroutine()
    {
        yield return new WaitForSeconds(8f);
        spawnHealth = true;
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


