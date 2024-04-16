using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class controllerSetup : MonoBehaviour
{

    public int playerNumber; // Assigned by the GameManager when the player is spawned
    private Vector2 moveInput;

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        // Use moveInput for player movement
    }
}


