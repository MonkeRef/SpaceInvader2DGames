using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Projectile : MonoBehaviour {

    [SerializeField] private int projectileSpeed = 5;
    private GameHandler gameHandler;

    private void Start () {
        gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
    }

    private void Update () {
        transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.CompareTag("Enemy")){
            Destroy(collision.gameObject);
            gameHandler.ScoreUpdate(100);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Boundary")) {
            Destroy(gameObject);
        }
    }
}
