using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUI : MonoBehaviour
{

    private void Awake () {
        Show();
    }

    private void Start () {
        GameHandler.Instance.OnGamePaused += GameHandler_OnGamePaused;
        GameHandler.Instance.OnGameUnpaused += GameHandler_OnGameUnpaused;
    }

    private void GameHandler_OnGamePaused (object sender, System.EventArgs e) {
        Hide();
    }

    private void GameHandler_OnGameUnpaused (object sender, System.EventArgs e) {
        Show();
    }

    private void Show () {
        gameObject.SetActive(true);
    }

    private void Hide () {
        gameObject.SetActive(false);

    }
}
