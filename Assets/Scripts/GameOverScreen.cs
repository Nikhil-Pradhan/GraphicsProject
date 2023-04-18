using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {

    public Text resultText;
    public Text scoreText;
    public Text highScoreText;

    public void Setup (float score, float highScore, bool won) {
        gameObject.SetActive(true);
        if (won)
            resultText.text = "YOU WIN";
        else
            resultText.text = "GAME OVER";
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