using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform[] spawnPoints; // Set these in the Inspector
    private PlayerInputManager playerInputManager;
    public controllingPlayer[] players;

    void Update()
    {
        CheckForWinner();
    }

    void CheckForWinner()
    {
        int playersWithLives = 0;
        controllingPlayer lastPlayerWithLives = null;

        foreach (var player in players)
        {
            if (player.lives > 0)
            {
                playersWithLives++;
                lastPlayerWithLives = player;
            }
        }

        if (playersWithLives == 1)
        {
            Debug.Log(lastPlayerWithLives.gameObject.name + " wins!");
            // Optionally, restart the game or go to a win screen
        }
        else if (playersWithLives == 0)
        {
            Debug.Log("No players left. It's a tie!");
            // Handle tie scenario
        }
    }

    void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
    }

    public void SpawnPlayer(int playerIndex)
    {
        if (playerIndex < spawnPoints.Length)
        {
            GameObject player = Instantiate(playerPrefab, spawnPoints[playerIndex].position, Quaternion.identity);
            // Additional setup for the player (e.g., assigning player number)
            player.GetComponent<controllerSetup>().playerNumber = playerIndex + 1;
        }
        else
        {
            Debug.LogWarning("Spawn point index out of range.");
        }
    }

    // Call this method for each connected controller
    public void AssignControllerToPlayer(InputDevice device, int playerIndex)
    {
        playerInputManager.JoinPlayer(playerIndex, -1, null, device);
    }
}
