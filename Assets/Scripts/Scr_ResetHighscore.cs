using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_ResetHighscore : MonoBehaviour
{
    public void resetHighScore()
    {
        PlayerPrefs.DeleteKey("Highscore");
    }
}
