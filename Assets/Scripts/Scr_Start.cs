using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scr_Start : MonoBehaviour
{
    public TMP_Text countdownText;
    public int readyTime = 1; // Time for "Ready"
    public int setTime = 1; // Time for "Set"
    public int goTime = 1; // Time for "Go!"

    // Code to play the game music
    public GameObject MusicPlayer;
    public AudioSource AudSrc;

    // References to starting beeps
    public AudioClip[] startingBeeps;
    public bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    /* // Update is called once per frame
    void Update()
    {

    } */
    public void startGame()
    {
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        countdownText.text = "Ready";
        AudSrc.volume = 1;
        AudSrc.PlayOneShot(startingBeeps[0]);
        yield return new WaitForSecondsRealtime(readyTime);

        countdownText.text = "Set";
        AudSrc.PlayOneShot(startingBeeps[1]);
        yield return new WaitForSecondsRealtime(setTime);

        countdownText.text = "Go!";
        AudSrc.PlayOneShot(startingBeeps[2]);
        yield return new WaitForSecondsRealtime(goTime);

        countdownText.text = ""; // Clear the text

        // Execute your code here (e.g., start the game, spawn objects, etc.)
        Debug.Log("Game started!");

        Time.timeScale = 1;

        AudSrc = MusicPlayer.GetComponent<AudioSource>();
        AudSrc.loop = true;
        AudSrc.volume = 0.25f;
        AudSrc.Play();
        gameStarted = true;

        gameObject.SetActive(false);

        
    }
}
