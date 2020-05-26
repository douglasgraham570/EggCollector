using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int highScore = 0;
    public static int score = 0;

    //public Text scoreText;
    public Text highScoreText;

    
    void Awake()
    {

        //get and display the high score from playerPrefs
        highScore = PlayerPrefs.GetInt("High Score",0);

        highScoreText.text = "High Score: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = "High Score: " + highScore;

        //update high score in player prefs if reached
        if (highScore > PlayerPrefs.GetInt("High Score", 0))
        {
            PlayerPrefs.SetInt("High Score", highScore);
        }
    }
}
