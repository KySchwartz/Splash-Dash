using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Scr_Manager3 : MonoBehaviour
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

    GameObject spawnedObstacle;
    GameObject spawnedCollectable;
    GameObject spawnedHealth;
    CapsuleCollider2D obCollider;
    CapsuleCollider2D colCollider;

    private void Start()
    {
        // At the start, tell the program to spawn a new obstacle every 3 seconds
        SpawnFirstObstacle();
        SpawnFirstCollectable();
        InvokeRepeating("SpawnObstacle", 2f, 3f);
        InvokeRepeating("SpawnCollectable", 1f, 2f);
        InvokeRepeating("SpawnHealth", 10f, 10f);
    }

    void SpawnObstacle()
    {
        // Create the spawn position for the obstacles by using a given X-position and choose a random Y-value given a minimum and a maximum
        obstacleSpawnPos = new Vector2(obstacleSpawnX, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));

        // Create the obstacle at the new position, and name it, so we can reference it
        spawnedObstacle = Instantiate(obstacles[UnityEngine.Random.Range(0, obstacles.Length)], obstacleSpawnPos, Quaternion.identity);
        obCollider = spawnedObstacle.GetComponent<CapsuleCollider2D>();

        // Destroy the obstacle after sufficient time has passed to preserve memory
        Destroy(spawnedObstacle, 8f);
    }

    void SpawnCollectable()
    {
        // Create the spawn position for the obstacles by using a given X-position and choose a random Y-value given a minimum and a maximum
        collectableSpawnPos = new Vector2(obstacleSpawnX + 2, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));

        // Create the obstacle at the new position, and name it, so we can reference it
        spawnedCollectable = Instantiate(collectables[UnityEngine.Random.Range(0, collectables.Length)], collectableSpawnPos, Quaternion.identity);
        colCollider = spawnedCollectable.GetComponent<CapsuleCollider2D>();


        // Destroy the obstacle after sufficient time has passed to preserve memory
        Destroy(spawnedCollectable, 10f);
    }

    void SpawnHealth()
    {
        // Create the spawn position for the obstacles by using a given X-position and choose a random Y-value given a minimum and a maximum
        healthSpawnPos = new Vector2(obstacleSpawnX + 1, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));

        Debug.Log("checking location");
        bool touchingObs = IsPointInsideCapsule(healthSpawnPos, obCollider);
        bool touchingCol = IsPointInsideCapsule(healthSpawnPos, colCollider);

        if (touchingObs || touchingCol)
        {
            Debug.Log("had to move");
            while (touchingObs || touchingCol)
            {
                // Create the obstacle at the new position, and name it, so we can reference it
                healthSpawnPos = new Vector2(obstacleSpawnX + 1, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));
                touchingObs = IsPointInsideCapsule(healthSpawnPos, obCollider);
                touchingCol = IsPointInsideCapsule(healthSpawnPos, colCollider);
            }
            Debug.Log("Had to move");
            spawnedHealth = Instantiate(health[UnityEngine.Random.Range(0, health.Length)], healthSpawnPos, Quaternion.identity);
        }
        else
        {
            spawnedHealth = Instantiate(health[UnityEngine.Random.Range(0, health.Length)], healthSpawnPos, Quaternion.identity);
        }


        // Destroy the obstacle after sufficient time has passed to preserve memory
        Destroy(spawnedHealth, 10f);
    }

    /*
        void SpawnObstacle()
        {
            // Create the spawn position for the obstacles by using a given X-position and choose a random Y-value given a minimum and a maximum
            obstacleSpawnPos = new Vector2(obstacleSpawnX, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));

            bool isInside = IsPointInsideCapsule(obstacleSpawnPos, colCollider);

            if (isInside)
            {
                while (isInside)
                {
                    // Create the obstacle at the new position, and name it, so we can reference it
                    obstacleSpawnPos = new Vector2(obstacleSpawnX, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));
                    obCollider = spawnedObstacle.GetComponent<CapsuleCollider2D>();
                    isInside = IsPointInsideCapsule(obstacleSpawnPos, colCollider);
                }
                spawnedObstacle = Instantiate(obstacles[UnityEngine.Random.Range(0, obstacles.Length)], obstacleSpawnPos, Quaternion.identity);
            }
            else
            {
                spawnedObstacle = Instantiate(obstacles[UnityEngine.Random.Range(0, obstacles.Length)], obstacleSpawnPos, Quaternion.identity);
                obCollider = spawnedObstacle.GetComponent<CapsuleCollider2D>();
            }

            // Destroy the obstacle after sufficient time has passed to preserve memory
            Destroy(spawnedObstacle, 8f);
        }

        void SpawnCollectable()
        {
            // Create the spawn position for the obstacles by using a given X-position and choose a random Y-value given a minimum and a maximum
            collectableSpawnPos = new Vector2(obstacleSpawnX + 2, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));

            bool isInside = IsPointInsideCapsule(collectableSpawnPos, obCollider);

            if (isInside)
            {
                while (isInside)
                {
                    // Create the obstacle at the new position, and name it, so we can reference it
                    collectableSpawnPos = new Vector2(obstacleSpawnX, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));
                    colCollider = spawnedObstacle.GetComponent<CapsuleCollider2D>();
                    isInside = IsPointInsideCapsule(collectableSpawnPos, obCollider);
                }
                spawnedCollectable = Instantiate(collectables[UnityEngine.Random.Range(0, collectables.Length)], collectableSpawnPos, Quaternion.identity);
            }
            else
            {

                // Create the obstacle at the new position, and name it, so we can reference it
                spawnedCollectable = Instantiate(collectables[UnityEngine.Random.Range(0, collectables.Length)], collectableSpawnPos, Quaternion.identity);
                colCollider = spawnedObstacle.GetComponent<CapsuleCollider2D>();
            }

            // Destroy the obstacle after sufficient time has passed to preserve memory
            Destroy(spawnedCollectable, 10f);
        }

        void SpawnHealth()
        {
            // Create the spawn position for the obstacles by using a given X-position and choose a random Y-value given a minimum and a maximum
            healthSpawnPos = new Vector2(obstacleSpawnX + 1, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));

            bool isInsideOb = IsPointInsideCapsule(healthSpawnPos, obCollider);

            if (isInsideOb)
            {
                while (isInsideOb)
                {
                    // Create the obstacle at the new position, and name it, so we can reference it
                    healthSpawnPos = new Vector2(obstacleSpawnX, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));
                    isInsideOb = IsPointInsideCapsule(healthSpawnPos, obCollider);
                }
                spawnedHealth = Instantiate(health[UnityEngine.Random.Range(0, health.Length)], healthSpawnPos, Quaternion.identity);
            }
            else
            {
                // Create the obstacle at the new position, and name it, so we can reference it
                spawnedHealth = Instantiate(collectables[UnityEngine.Random.Range(0, health.Length)], healthSpawnPos, Quaternion.identity);
            }


            // Destroy the obstacle after sufficient time has passed to preserve memory
            Destroy(spawnedHealth, 10f);
        }

        */

    public bool IsPointInsideCapsule(Vector2 point, CapsuleCollider2D capCol)
    {
        Vector2 closestPoint = capCol.ClosestPoint(point);
        return Vector2.Distance(point, closestPoint) < 0.001f; // Tolerance for floating-point precision
    }

    /*
    public bool TestSpawnLocation(Vector2 spawnPosition, float spawnRadius)
    {
        Collider[] colliders = Physics.OverlapSphere(spawnPosition, spawnRadius);
        if (colliders.Length == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    */

    void SpawnFirstObstacle()
    {
        // Create the spawn position for the obstacles by using a given X-position and choose a random Y-value given a minimum and a maximum
        obstacleSpawnPos = new Vector2(obstacleSpawnX, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));


        // Create the obstacle at the new position, and name it, so we can reference it
        spawnedObstacle = Instantiate(obstacles[UnityEngine.Random.Range(0, obstacles.Length)], obstacleSpawnPos, Quaternion.identity);
        obCollider = spawnedObstacle.GetComponent<CapsuleCollider2D>();

        // Destroy the obstacle after sufficient time has passed to preserve memory
        Destroy(spawnedObstacle, 8f);
    }

    void SpawnFirstCollectable()
    {
        // Create the spawn position for the obstacles by using a given X-position and choose a random Y-value given a minimum and a maximum
        collectableSpawnPos = new Vector2(obstacleSpawnX + 3, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));


        // Create the obstacle at the new position, and name it, so we can reference it
        spawnedCollectable = Instantiate(collectables[UnityEngine.Random.Range(0, collectables.Length)], collectableSpawnPos, Quaternion.identity);
        colCollider = spawnedObstacle.GetComponent<CapsuleCollider2D>();


        // Destroy the obstacle after sufficient time has passed to preserve memory
        Destroy(spawnedCollectable, 10f);
    }
}


/*
void SpawnObstacle()
{
    // Create the spawn position for the obstacles by using a given X-position and choose a random Y-value given a minimum and a maximum
    obstacleSpawnPos = new Vector2(obstacleSpawnX, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));

    bool isInside = IsPointInsideCapsule(obstacleSpawnPos, colCollider);

    if (!isInside)
    {
        // Create the obstacle at the new position, and name it, so we can reference it
        spawnedObstacle = Instantiate(obstacles[UnityEngine.Random.Range(0, obstacles.Length)], obstacleSpawnPos, Quaternion.identity);
        obCollider = spawnedObstacle.GetComponent<CapsuleCollider2D>();
    }
    else
    {
        obstacleSpawnPos = new Vector2(obstacleSpawnX, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));
        spawnedObstacle = Instantiate(obstacles[UnityEngine.Random.Range(0, obstacles.Length)], obstacleSpawnPos, Quaternion.identity);
        obCollider = spawnedObstacle.GetComponent<CapsuleCollider2D>();
    }

    // Destroy the obstacle after sufficient time has passed to preserve memory
    Destroy(spawnedObstacle, 8f);
}

void SpawnCollectable()
{
    // Create the spawn position for the obstacles by using a given X-position and choose a random Y-value given a minimum and a maximum
    collectableSpawnPos = new Vector2(obstacleSpawnX + 2, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));

    bool isInside = IsPointInsideCapsule(collectableSpawnPos, obCollider);

    if (!isInside)
    {
        // Create the obstacle at the new position, and name it, so we can reference it
        spawnedCollectable = Instantiate(collectables[UnityEngine.Random.Range(0, collectables.Length)], collectableSpawnPos, Quaternion.identity);
        colCollider = spawnedObstacle.GetComponent<CapsuleCollider2D>();
    }
    else
    {
        collectableSpawnPos = new Vector2(obstacleSpawnX, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));
        // Create the obstacle at the new position, and name it, so we can reference it
        spawnedCollectable = Instantiate(collectables[UnityEngine.Random.Range(0, collectables.Length)], collectableSpawnPos, Quaternion.identity);
        colCollider = spawnedObstacle.GetComponent<CapsuleCollider2D>();
    }

    // Destroy the obstacle after sufficient time has passed to preserve memory
    Destroy(spawnedCollectable, 10f);
}
*/




/*
public GameObject objectToSpawn;
public float spawnRadius = 0.1f;

private void SpawnObject(Vector3 spawnPosition)
{
    Collider[] colliders = Physics.OverlapSphere(spawnPosition, spawnRadius);
    if (colliders.Length == 0)
    {
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
    else
    {
        Debug.Log("Cannot spawn. Location is occupied.");
    }
}
*/





/*
    void SpawnObstacle()
    {
        // Create the spawn position for the obstacles by using a given X-position and choose a random Y-value given a minimum and a maximum
        obstacleSpawnPos = new Vector2(obstacleSpawnX, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));

        bool isInside = IsPointInsideCapsule(obstacleSpawnPos, colCollider);

        if (isInside)
        {
            while (isInside)
            {
                // Create the obstacle at the new position, and name it, so we can reference it
                obstacleSpawnPos = new Vector2(obstacleSpawnX, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));
                obCollider = spawnedObstacle.GetComponent<CapsuleCollider2D>();
                isInside = IsPointInsideCapsule(obstacleSpawnPos, colCollider);
            }
            spawnedObstacle = Instantiate(obstacles[UnityEngine.Random.Range(0, obstacles.Length)], obstacleSpawnPos, Quaternion.identity);
        }
        else
        {
            spawnedObstacle = Instantiate(obstacles[UnityEngine.Random.Range(0, obstacles.Length)], obstacleSpawnPos, Quaternion.identity);
            obCollider = spawnedObstacle.GetComponent<CapsuleCollider2D>();
        }

        // Destroy the obstacle after sufficient time has passed to preserve memory
        Destroy(spawnedObstacle, 8f);
    }

    void SpawnCollectable()
    {
        // Create the spawn position for the obstacles by using a given X-position and choose a random Y-value given a minimum and a maximum
        collectableSpawnPos = new Vector2(obstacleSpawnX + 2, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));

        bool isInside = IsPointInsideCapsule(collectableSpawnPos, obCollider);

        if (isInside)
        {
            while (isInside)
            {
                // Create the obstacle at the new position, and name it, so we can reference it
                collectableSpawnPos = new Vector2(obstacleSpawnX, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));
                colCollider = spawnedObstacle.GetComponent<CapsuleCollider2D>();
                isInside = IsPointInsideCapsule(collectableSpawnPos, obCollider);
            }
            spawnedCollectable = Instantiate(collectables[UnityEngine.Random.Range(0, collectables.Length)], collectableSpawnPos, Quaternion.identity);
        }
        else
        {
            
            // Create the obstacle at the new position, and name it, so we can reference it
            spawnedCollectable = Instantiate(collectables[UnityEngine.Random.Range(0, collectables.Length)], collectableSpawnPos, Quaternion.identity);
            colCollider = spawnedObstacle.GetComponent<CapsuleCollider2D>();
        }

        // Destroy the obstacle after sufficient time has passed to preserve memory
        Destroy(spawnedCollectable, 10f);
    }

    void SpawnHealth()
    {
        // Create the spawn position for the obstacles by using a given X-position and choose a random Y-value given a minimum and a maximum
        healthSpawnPos = new Vector2(obstacleSpawnX + 1, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));

        bool isInsideOb = IsPointInsideCapsule(healthSpawnPos, obCollider);

        if (isInsideOb)
        {
            while (isInsideOb)
            {
                // Create the obstacle at the new position, and name it, so we can reference it
                healthSpawnPos = new Vector2(obstacleSpawnX, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));
                isInsideOb = IsPointInsideCapsule(healthSpawnPos, obCollider);
            }
            spawnedHealth = Instantiate(health[UnityEngine.Random.Range(0, health.Length)], healthSpawnPos, Quaternion.identity);
        }
        else
        {
            // Create the obstacle at the new position, and name it, so we can reference it
            spawnedHealth = Instantiate(collectables[UnityEngine.Random.Range(0, health.Length)], healthSpawnPos, Quaternion.identity);
        }


        // Destroy the obstacle after sufficient time has passed to preserve memory
        Destroy(spawnedHealth, 10f);
    }
*/

/*
    void SpawnObstacle()
    {
        // Create the spawn position for the obstacles by using a given X-position and choose a random Y-value given a minimum and a maximum
        obstacleSpawnPos = new Vector2(obstacleSpawnX, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));

        // Create the obstacle at the new position, and name it, so we can reference it
        spawnedObstacle = Instantiate(obstacles[UnityEngine.Random.Range(0, obstacles.Length)], obstacleSpawnPos, Quaternion.identity);
        obCollider = spawnedObstacle.GetComponent<CapsuleCollider2D>();

        // Destroy the obstacle after sufficient time has passed to preserve memory
        Destroy(spawnedObstacle, 8f);
    }

    void SpawnCollectable()
    {
        // Create the spawn position for the obstacles by using a given X-position and choose a random Y-value given a minimum and a maximum
        collectableSpawnPos = new Vector2(obstacleSpawnX + 2, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));

        // Create the obstacle at the new position, and name it, so we can reference it
        spawnedCollectable = Instantiate(collectables[UnityEngine.Random.Range(0, collectables.Length)], collectableSpawnPos, Quaternion.identity);
        colCollider = spawnedCollectable.GetComponent<CapsuleCollider2D>();


        // Destroy the obstacle after sufficient time has passed to preserve memory
        Destroy(spawnedCollectable, 10f);
    }

    void SpawnHealth()
    {
        // Create the spawn position for the obstacles by using a given X-position and choose a random Y-value given a minimum and a maximum
        healthSpawnPos = new Vector2(obstacleSpawnX + 1, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));

        Debug.Log("checking location");
        bool touchingObs = IsPointInsideCapsule(healthSpawnPos, obCollider);
        bool touchingCol = IsPointInsideCapsule(healthSpawnPos, colCollider);

        if (touchingObs || touchingCol)
        {
            Debug.Log("had to move");
            while (touchingObs || touchingCol)
            {
                // Create the obstacle at the new position, and name it, so we can reference it
                healthSpawnPos = new Vector2(obstacleSpawnX + 1, UnityEngine.Random.Range(obstacleSpawnYMin, obstacleSpawnYMax));
                touchingObs = IsPointInsideCapsule(healthSpawnPos, obCollider);
                touchingCol = IsPointInsideCapsule(healthSpawnPos, colCollider);
            }
            Debug.Log("Had to move");
            spawnedHealth = Instantiate(health[UnityEngine.Random.Range(0, health.Length)], healthSpawnPos, Quaternion.identity);
        }
        else
        {
            spawnedHealth = Instantiate(health[UnityEngine.Random.Range(0, health.Length)], healthSpawnPos, Quaternion.identity);
        }


        // Destroy the obstacle after sufficient time has passed to preserve memory
        Destroy(spawnedHealth, 10f);
    }
*/