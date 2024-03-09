using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text scoreText;
    public void setUp(int score)
    {
        gameObject.SetActive(true);
        scoreText.text = "Score: " + score.ToString();
    }
}
