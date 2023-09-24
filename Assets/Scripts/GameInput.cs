using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{

    private PlayerInputActions playerInputActions; // Using new input system

    private bool isAttack = false;

    private void Awake () {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable(); // Enable the new input system
    }


    public Vector2 GetMovementInputNormalized () {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>(); // Read Vector2 value from pressing keybinds
        inputVector = inputVector.normalized; // Normalized it
        return inputVector;
    }

    public bool GetAttackInput () {
        if (playerInputActions.Player.Fire.triggered) {
            isAttack = !isAttack;
        }
        return isAttack;
    }
}
