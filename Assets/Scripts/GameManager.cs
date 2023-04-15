using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay;
    public GameOverScreen GameOverScreen;

    public void EndGame(int score) {
        if (!gameHasEnded) {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GameOverScreen.Setup(score);
            // Invoke("Restart",restartDelay);
        }
    }

    private void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
