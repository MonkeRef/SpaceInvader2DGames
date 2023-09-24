using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndedUI : MonoBehaviour
{
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button quitButton;

    private void Awake () {
        playAgainButton.onClick.AddListener(() => {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload Game Scene
        });

        quitButton.onClick.AddListener(() => {
            Application.Quit(); // Quit Game
        });
    }

    private void Start () {
        Hide();
        LivesRelated.Instance.OnGameEnded += LivesRelated_OnGameEnded;
    }

    private void LivesRelated_OnGameEnded (object sender, System.EventArgs e) {
        Time.timeScale = 0f;
        Show();
    }

    private void Show () {
        gameObject.SetActive(true);
    }

    private void Hide () {
        gameObject.SetActive(false);

    }
}
