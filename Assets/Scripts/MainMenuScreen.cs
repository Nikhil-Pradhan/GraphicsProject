using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour {

    public ControlsScreen ControlsScreen;

    public void ControlsButton() {
        ControlsScreen.SetUp();
    }

    public void PlayGameButton() {
        SceneManager.LoadScene("Game");
    }

    public void ExitButton() {
        Application.Quit();
    }
}