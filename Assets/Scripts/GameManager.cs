using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameOverScreen GameOverScreen;

    public void EndGame(int score, int highScore) {
        if (!gameHasEnded) {
            gameHasEnded = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GameOverScreen.Setup(score, highScore);
        }
    }
}
