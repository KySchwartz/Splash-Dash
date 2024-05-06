using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_Obstacle : MonoBehaviour
{
    public float totalGameTime;

    public float speed;

    // Variables for dynamic linear speed control
    public float speedChangeRate = 0.0108f;
    // First maxSpeed was set to 4f
    // Second maxSpeed was set to 6f
    // Third maxSpeed was set to 5.5f
    //public float maxSpeed = 5.5f;
    //public float initialSpeed = 2f;
    public float maxSpeed = 5.5f;
    public float initialSpeed = 2f;

    private void Start()
    {
        //InvokeRepeating("moveObs", 0f, 0.00417f);

        // Set the dynamic difficulty variables
        speedChangeRate = 0.0108f;
        // Original maxSpeed is 8.5 using invoke repeating method
        maxSpeed = 9f;

    }

    // Update is called once per frame
    void Update()
    {
        if (speed < maxSpeed)
        {
            //speed = speedChangeRate * StaticTimer.totalGameTime + 1.85f;
            speed = speedChangeRate * StaticTimer.totalGameTime + 5.5f;
        }
        else
        {
            speed = maxSpeed;
        }
        //Debug.Log(speed);

        // Move ths obstacle to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime * Time.timeScale);
    } 
    
    /*
    private void moveObs()
    {
        // Move the obstacle to the left
        //transform.Translate((-speed / 100) * Time.timeScale, 0, 0);
        //transform.Translate(Vector3.left * speed * Time.deltaTime * Time.timeScale);
    }
    */
}

