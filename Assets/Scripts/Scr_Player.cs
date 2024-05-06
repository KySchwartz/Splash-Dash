using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scr_Player : MonoBehaviour
{
    public Scr_Timer Timer;
    public Scr_Score Score;
    public Scr_Manager Manager;

    // Used to reference the audio source
    AudioSource AS;
    public AudioSource BackgroundEffects;

    public float speed;
    public float minYLevel;
    public float maxYLevel;
    //public float jumpHeight;

    public GameObject player;
    public AnimationClip hit;
    public Animator anim;

    // Create lists to hold the game sound effects
    public AudioClip[] hitSound;
    public AudioClip[] collectSound;
    public AudioClip[] timeBoostSound;
    public AudioClip[] startSound;

    public Scr_Mobile MobileUpBtn;
    public Scr_Mobile MobileDownBtn;

    // Start is called before the first frame update
    void Start()
    {
        // Set up the player to play sounds
        AS = GetComponent<AudioSource>();
        StartCoroutine(PlayStartSoundAfterDelay(0.5f));

        anim = player.GetComponent<Animator>();
        //anim.Play("Swimming");

        InvokeRepeating("MovePlayer", 0f, 0.0083f);
    }

    /*   // Update is called once per frame
       void Update()
       {
           // Check to make sure player is pressing 'W' and they are below the surface of the water
           if (Input.GetKey(KeyCode.W) && transform.position.y <= maxYLevel)
           {
               // Move up at a constant speed
               transform.Translate(0, (speed / 100)*Time.timeScale, 0);
           }
           // Check to make sure the player is pressing 'S' and they are above the ocean floor
           if (Input.GetKey(KeyCode.S) && transform.position.y >= minYLevel)
           {
               // Move up at a constant speed
               transform.Translate(0, (-speed / 100)*Time.timeScale, 0);
           }

           // Added support for up and down arrow key input
           // Check to make sure player is pressing the up arrow and they are below the surface of the water
           if (Input.GetKey(KeyCode.UpArrow) && transform.position.y <= maxYLevel)
           {
               // Move up at a constant speed
               transform.Translate(0, (speed / 100) * Time.timeScale, 0);
           }
           // Check to make sure the player is pressing down arrow and they are above the ocean floor
           if (Input.GetKey(KeyCode.DownArrow) && transform.position.y >= minYLevel)
           {
               // Move up at a constant speed
               transform.Translate(0, (-speed / 100) * Time.timeScale, 0);
           }

           // Added support for mobile GUI controls
           if (StaticData.isMobile)
           {
               // Check to make sure player is pressing 'W' and they are below the surface of the water
               if (MobileUpBtn.buttonPressed && transform.position.y <= maxYLevel)
               {
                   // Move up at a constant speed
                   transform.Translate(0, (speed / 100) * Time.timeScale, 0);
               }
               // Check to make sure the player is pressing 'S' and they are above the ocean floor
               if (MobileDownBtn.buttonPressed && transform.position.y >= minYLevel)
               {
                   // Move up at a constant speed
                   transform.Translate(0, (-speed / 100) * Time.timeScale, 0);
               }
           }

       } */

    public void MovePlayer()
    {
        // Check to make sure player is pressing 'W' and they are below the surface of the water
        if (Input.GetKey(KeyCode.W) && transform.position.y <= maxYLevel)
        {
            // Move up at a constant speed
            transform.Translate(0, (speed / 100) * Time.timeScale, 0);
        }
        // Check to make sure the player is pressing 'S' and they are above the ocean floor
        if (Input.GetKey(KeyCode.S) && transform.position.y >= minYLevel)
        {
            // Move up at a constant speed
            transform.Translate(0, (-speed / 100) * Time.timeScale, 0);
        }

        // Added support for up and down arrow key input
        // Check to make sure player is pressing the up arrow and they are below the surface of the water
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y <= maxYLevel)
        {
            // Move up at a constant speed
            transform.Translate(0, (speed / 100) * Time.timeScale, 0);
        }
        // Check to make sure the player is pressing down arrow and they are above the ocean floor
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y >= minYLevel)
        {
            // Move up at a constant speed
            transform.Translate(0, (-speed / 100) * Time.timeScale, 0);
        }

        // Added support for mobile GUI controls
        if (StaticData.isMobile)
        {
            // Check to make sure player is pressing 'W' and they are below the surface of the water
            if (MobileUpBtn.buttonPressed && transform.position.y <= maxYLevel)
            {
                // Move up at a constant speed
                transform.Translate(0, (speed / 100) * Time.timeScale, 0);
            }
            // Check to make sure the player is pressing 'S' and they are above the ocean floor
            if (MobileDownBtn.buttonPressed && transform.position.y >= minYLevel)
            {
                // Move up at a constant speed
                transform.Translate(0, (-speed / 100) * Time.timeScale, 0);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with " + collision.name);

        // Test for which obstacle the player collides with...

        if (collision.name.Contains("Obs"))
        {
            // Decrease timer by 5 seconds
            Timer.TimeLeft -= 10;

            // Play the hit animation
            anim.Play("ObstacleHit");

            // Play the hit sound
            AS.PlayOneShot(hitSound[UnityEngine.Random.Range(0, hitSound.Length)]);
        }
        if (collision.name.Contains("Bubble"))
        {
            // Increase timer by 10 seconds
            Timer.TimeLeft += 10;

            // Play the collection animation
            anim.Play("Collection");

            // Remove the object from the game
            Destroy(collision.gameObject);

            // Play the collection sound
            AS.PlayOneShot(timeBoostSound[UnityEngine.Random.Range(0, timeBoostSound.Length)]);
        }
        if (collision.name.Contains("Collect"))
        {
            // Increase the score by 1
            Score.score++;

            // Remove the object from the game
            Destroy(collision.gameObject);

            // Play the collection sound
            //BackgroundEffects.PlayOneShot(collectSound[0]);
            AS.PlayOneShot(collectSound[UnityEngine.Random.Range(0, collectSound.Length)]);
        }
    }

    private IEnumerator PlayStartSoundAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay

        // Play the sound effect
        AS.PlayOneShot(startSound[UnityEngine.Random.Range(0, startSound.Length)]);
    }
}






/*       // Check if dolphin is at waterline
       if (transform.position.y > maxYLevel)
       {
           transform.Translate(0, speed / 100, 0);

       }
       // Cap off the jump
       if (transform.position.y >= jumpHeight)
       {
           transform.Translate(0, -speed / 100, 0);
       }
*/