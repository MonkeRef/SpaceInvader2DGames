using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesRelated : MonoBehaviour{

    public static LivesRelated Instance { get; private set; }

    public event EventHandler OnGameEnded;
    [SerializeField] private Image[] livesUI;
    private int lives = 3;

    private void Awake () {
        Instance = this;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.collider.gameObject.CompareTag("Enemy")) {
            Destroy(collision.collider.gameObject);
            lives -= 1;
            for(int i = 0; i < livesUI.Length; i++) {
                if(i < lives) {
                    livesUI[i].enabled = true;
                } else {
                    livesUI[i].enabled = false;
                }
            }

            if (lives <= 0) {
                Destroy(gameObject);
                OnGameEnded?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
