using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {

    public Text scoreText;

    public void Setup (int score) {
        gameObject.SetActive(true);
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void RestartButton() {
        SceneManager.LoadScene("Game");
    }

    public void ExitButton() {
        Application.Quit();
    }
}