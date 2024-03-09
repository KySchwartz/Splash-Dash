using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Scr_Distance : MonoBehaviour
{
    private float gameStartTime;
    public float totalGameTime;

    public TMP_Text distanceText;
    public float distance;

    private void Start()
    {
        // Record the initial game start time
        gameStartTime = Time.time;

        // Set distance to 0
        distance = 0;
        printDistance();
    }

    private void Update()
    {
        // Only update the total game time if timeScale is not 0
        if (Time.timeScale != 0f)
        {
            // Calculate the elapsed time since the game started
            totalGameTime = Time.time - gameStartTime;

            // You can use 'totalGameTime' for any game-related logic
            // For example, display it on the UI or trigger events after a certain duration

            printDistance();
        }
    }

    public void printDistance()
    {
        distance = totalGameTime / 10;
        distanceText.text = "Distance: " + distance.ToString("0.0000");
    }

    // Example usage: Display the total game time in seconds
/*    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), $"Total Game Time: {totalGameTime:F2} seconds");
    }   */
}
