using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MusicManager : MonoBehaviour
{
    // I left this code in case I needed it, but I was able to perform the same function without calling a method each frame in the pause script


  /*  [SerializeField] Scr_Start musicStarter;
    public AudioSource AudSrc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Pause the music if the game is paused
        if (Time.timeScale == 0 && musicStarter.gameStarted == true)
        {
            AudSrc.Pause();
        }
        else if (Time.timeScale == 1 && AudSrc.isPlaying == false)
        {
            AudSrc.UnPause();
        }
    } */
}
