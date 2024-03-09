using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Obstacle : MonoBehaviour
{
    private float gameStartTime;
    public float totalGameTime;

    public float speed;

    private void Start()
    {
        InvokeRepeating("moveObs", 0f, 0.00417f);
    }

 /*   // Update is called once per frame
    void Update()
    {
        // Move the obstacle to the left
        transform.Translate((-speed / 100) * Time.timeScale, 0, 0);

        // Only update the total game time if timeScale is not 0
        if (Time.timeScale != 0f)
        {
            // Calculate the elapsed time since the game started
            totalGameTime = Time.time - gameStartTime;

            CheckTime();
        }
    } */

    private void moveObs()
    {
        // Move the obstacle to the left
        transform.Translate((-speed / 100) * Time.timeScale, 0, 0);

        // Only update the total game time if timeScale is not 0
        if (Time.timeScale != 0f)
        {
            // Calculate the elapsed time since the game started
            totalGameTime = Time.time - gameStartTime;

            CheckTime();
        }
    }

    private void CheckTime()
    {
        if (totalGameTime < 15)
        {
            speed = 2f;
        }
        else if (totalGameTime < 30)
        {
            speed = 2.25f;
        }
        else if (totalGameTime < 45)
        {
            speed = 2.50f;
        }
        else if (totalGameTime < 60)
        {
            speed = 2.75f;
        }
        else if (totalGameTime < 75)
        {
            speed = 3f;
        }
        else if (totalGameTime < 90)
        {
            speed = 3.25f;
        }
        else if (totalGameTime < 105)
        {
            speed = 3.50f;
        }
        else if (totalGameTime < 145)
        {
            speed = 3.75f;
        }
        else if (totalGameTime > 200)
        {
            speed = 4f;
        }
    }
}

