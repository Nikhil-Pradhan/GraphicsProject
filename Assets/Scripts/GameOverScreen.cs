using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;

    public void Setup (float score, float highScore) {
        gameObject.SetActive(true);
        scoreText.text = "SCORE: " + score.ToString();
        highScoreText.text = "HIGH SCORE: " + highScore.ToString();
    }

    public void RestartButton() {
        SceneManager.LoadScene("Game");
    }

    public void MainMenuButton() {
        SceneManager.LoadScene("MainMenu");
    }
}