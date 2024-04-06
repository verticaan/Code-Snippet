using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public GameOverMenu gameOverMenu;

    public int startingLives = 4;
    public int lives;

    public static int totalLives = 0;

    [SerializeField] TMP_Text livesText;

    private void Awake()
    {
        totalLives = 0;
    }

    private void Start()
    {
        lives = startingLives;
        totalLives += lives;
        UpdateLivesText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacles"))
        {
            lives--;
            totalLives--;
            UpdateLivesText();

            if (lives <= 0)
            {
                Destroy(gameObject);
                Time.timeScale = 0f;
                gameOverMenu.ShowGameOverMenu();
            }
        }
    }

    private void UpdateLivesText()
    {
        livesText.text = "Lives: " + lives;

        // update the total number of lives for all players
        totalLives = 0;
        foreach (PlayerHealth player in GameManager.instance.players)
        {
            totalLives += player.lives;
        }

        // update the lives text for all players
        foreach (PlayerHealth player in GameManager.instance.players)
        {
            player.livesText.text = "Lives: " + player.lives;
        }
    }
}
