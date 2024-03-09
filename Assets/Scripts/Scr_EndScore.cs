using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Scr_EndScore : MonoBehaviour
{
    public Scr_Score Score;
    public TMP_Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        ScoreText.text = "Score: " + Score.score.ToString();
    }
}
