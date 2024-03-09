using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Src_Eraser : MonoBehaviour
{

    public GameObject eraser;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Test for which obstacle the player collides with...

        if (collision.name.Contains("Obs"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.name.Contains("Bubble"))
        {
            // Remove the object from the game
            Destroy(collision.gameObject);
        }
        if (collision.name.Contains("Collect"))
        {
            // Remove the object from the game
            Destroy(collision.gameObject);
        }
    }
}
