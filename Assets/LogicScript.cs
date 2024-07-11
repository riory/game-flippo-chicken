using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class LogicScript : MonoBehaviour {
    public Text scoreText;
    public int playerScore = 0;
    public GameObject gameOverScreen;
    public AudioSource asBackground;
    public AudioSource asGameOver;

    private float timer = 0;
    private float fadeSec = 1;

    public bool isGameOver { get; private set; }
    private bool gameOverSoundStarted = false;

    [ContextMenu("Add score")]
    public void addScore(int scoreToAdd) {
        playerScore += scoreToAdd; 
        scoreText.text = playerScore.ToString();
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isGameOver = false;
    }

    public void gameOver() {
        gameOverScreen.SetActive(true);
        isGameOver = true;

    }

    public void Update() {
        if (isGameOver) {
            if (gameOverSoundStarted == false) {
                asGameOver.Play();
                gameOverSoundStarted = true;
            }
            // fade background music
            float newVolume = asBackground.volume - (0.1f * Time.deltaTime);
            if (newVolume < 0f) {
                newVolume = 0f;
            }
            asBackground.volume = newVolume;
        }
    }
}
