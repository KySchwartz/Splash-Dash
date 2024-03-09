using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scr_Timer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;

    public TMP_Text TimerText;

    public GameOverScreen GameOverScreen;

    public Scr_TimeBar TimeBar;

    // References the object that starts the game's music playing
    [SerializeField] private Scr_Start StartCode;


    // Start is called before the first frame update
    void Start()
    {
        // Enable the timer on the start of the game
        TimerOn = true;

        // Set the time scale to zero so the game stays paused
        Time.timeScale = 0;

        // Set the initial max health of the timebar
        TimeBar.setMaxHealth(TimeLeft);
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            // While there is still time left on the timer...
            if (TimeLeft > 0)
            {
                // Decrease the amount on the timer and update the text
                TimeLeft -= Time.deltaTime;
                UpdateTimer(TimeLeft);

                // Set the timeBar based on the timeLeft
                TimeBar.setHealth(TimeLeft);
                if (TimeLeft > TimeBar.getMaxHealth())
                {
                    TimeBar.setMaxHealth(TimeLeft);
                }
            }
            // When there is no longer time left on the timer...
            else
            {
                // Disable the timer
                Debug.Log("Time is up");
                TimeLeft = 0;
                TimerOn = false;

                // and other things such as end the game...

                Time.timeScale = 0;
                GameOverScreen.setUp(0);
                // Stops the background music from playing
                StartCode.AudSrc.Stop();
            }
        }
    }

    void UpdateTimer(float _currentTime)
    {
        _currentTime += 1;

        // Define how many minutes/seconds there are left by using math
        float minutes = Mathf.FloorToInt(_currentTime / 60);
        float seconds = Mathf.FloorToInt(_currentTime % 60);

        // Format the text correctly and update the text
        TimerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
