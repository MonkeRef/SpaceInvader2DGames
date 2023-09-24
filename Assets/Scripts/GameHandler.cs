using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameHandler : MonoBehaviour {
    public static GameHandler Instance { get; private set; }

    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnpaused;

    [SerializeField] private TMP_Text scoreText;
    private bool isGamePaused = false;
    private int score = 0;

    private void Awake () {
        Instance = this;
        Time.timeScale = 1f;
    }

    private void Start () {
        scoreText.text = "Score : " + score; // Initiate score from 0
    }

    private void Update () {
        if (Input.GetKeyUp(KeyCode.Escape)) { // Pause game when Escape button pressed, If it doesn't work, change the KeyCode to something else
            TogglePauseGame();
        }
    }

    public void ScoreUpdate(int scores) {
        score += scores; 
        scoreText.text = "Score : " + score; // Display the current score
    }

    public void TogglePauseGame () {
        isGamePaused = !isGamePaused;
        if (isGamePaused) {
            Time.timeScale = 0f;
            OnGamePaused?.Invoke(this, EventArgs.Empty);
        } else {
            Time.timeScale = 1f;
            OnGameUnpaused?.Invoke(this, EventArgs.Empty);
        }
    }
}
