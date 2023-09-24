using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private GameInput gameInput;
    [SerializeField] private int moveSpeed;
    [SerializeField] private GameObject projectilePrefab;

    private Transform playerVisual;
    private bool isAttacking = false;
    private Vector3 playerVisualTransform;

    private void Awake () {
        GameObject spaceShip = GameObject.Find("SpaceShipVisual");
        if(spaceShip != null) {
            playerVisual = spaceShip.transform; // Taking Player Space Ship Visual Transform
        }
    }
    private void Update () {
        HandleMovement();
        OnAttack();
    }

    private void HandleMovement () {
        Vector2 inputVector = gameInput.GetMovementInputNormalized(); // Checking whether AD or Left and Right arrow keys performed
        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0f);

        transform.position += moveDir * moveSpeed * Time.deltaTime; // Updating transform position
    }

    private void OnAttack () {
        playerVisualTransform = new Vector3(playerVisual.position.x, playerVisual.position.y + 1, playerVisual.position.z); // Updating player space ship visual position
        isAttacking = gameInput.GetAttackInput(); // Checking whether Left mouse or Spacebar is clicked
        
        if (isAttacking) {
            Instantiate(projectilePrefab, playerVisualTransform, Quaternion.identity); // Spawn projectile infront of the player space ship visual position
        }
    }
}
