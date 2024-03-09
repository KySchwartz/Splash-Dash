using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Android;

public class Pause : MonoBehaviour
{

    // This is the original control variable before the pause overlay was created
    //private bool paused = false;

    public GameObject pauseOverlay;
    public AudioSource AudSrc;

   /* // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } */

    public void pause()
    {
        Time.timeScale = 0;
        pauseOverlay.SetActive(true);
        AudSrc.Pause();
        
        // This code allows the pause button to work independant of the pause overlay
        /*
        paused = !paused;

        if (paused)
        {
            Time.timeScale = 0;
            pauseOverlay.SetActive(true);
        }
        else
        {
            pauseOverlay.SetActive(false);
            Time.timeScale = 1;
        }
        */
    }

    public void resume()
    {
        pauseOverlay.SetActive(false);
        Time.timeScale = 1;
        AudSrc.UnPause();
    }
}
