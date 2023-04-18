using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlsScreen : MonoBehaviour {
    public void SetUp() {
        gameObject.SetActive(true);
    }

    public void MainMenuButton() {
        gameObject.SetActive(false);
    }
}