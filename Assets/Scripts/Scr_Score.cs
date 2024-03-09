using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scr_Score : MonoBehaviour
{
    public TMP_Text ScoreText;

    [SerializeField] private TextMeshProUGUI HighScoreText;
    [SerializeField] private TextMeshProUGUI HighScoreEndText;

    public int score;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        HighScoreEndText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0).ToString();
        // Use to reset the highscore to 0
        //resetHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        setScore(score);
        HighScoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0).ToString();
        updateHighScore();
    }

    public void setScore(int score)
    {
        ScoreText.text = "Score: " + score.ToString();
    }

    public void updateHighScore()
    {
        if (score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", score);
            HighScoreText.text = score.ToString();
            HighScoreEndText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0).ToString();
        }
    }

    public void resetHighScore()
    {
        PlayerPrefs.DeleteKey("Highscore");
    }
}

