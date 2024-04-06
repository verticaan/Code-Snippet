using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    public int score = 0;
    public int highscore = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0); // using player refs to save the score on the device on start
        scoreText.text = "Score: " + score; //initialises the score and highscore system to zero befor the game starts
        highscoreText.text = "Highscore: " + highscore;
    }

    public void UpdateScore(int points) //helps update the score when players collect pickups
    {
        score += points; //add score to an int called "point"
        scoreText.text = "Score: " + score;
        if (highscore < score)
        PlayerPrefs.SetInt("highscore", score); //use score to crate a highscore
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
