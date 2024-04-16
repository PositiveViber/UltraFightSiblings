using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonController : MonoBehaviour
{
    public string sceneName; // Assign the name of the scene you want to load in the Inspector
    public GameObject[] sprites; // Assign your sprite GameObjects in the inspector
    private GameObject[] playerSprites;
    private Vector3[] startingPositions;
    public string characterChoice;
    public void Activate()
    {
        // Load the scene with the given name
        Debug.Log("Attempting to load scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

    void playerChoicePractice()
    {
        if (characterChoice.Equals("knight"))
        {
            DestroyAllWithTag("warrior");
            DestroyAllWithTag("bladekeeper");
            DestroyAllWithTag("crystalmauler");
            //knight.addtag("player");
        }
        if (characterChoice.Equals("warrior"))
        {
            DestroyAllWithTag("knight");
            DestroyAllWithTag("bladekeeper");
            DestroyAllWithTag("crystalmauler");
        }
        if (characterChoice.Equals("bladekeeper"))
        {
            DestroyAllWithTag("knight");
            DestroyAllWithTag("warrior");
            DestroyAllWithTag("crystalmauler");

        }
        if (characterChoice.Equals("crystalmauler"))
        {
            DestroyAllWithTag("knight");
            DestroyAllWithTag("warrior");
            DestroyAllWithTag("bladekeeper");
        }
        else
        {
            Debug.Log("cry");
        }
    }

    public void QuitGame()
    {
        // If we are running in a standalone build of the game
        #if UNITY_STANDALONE
        // Quit the application
        Application.Quit();
        #endif

        // If we are running in the editor
        #if UNITY_EDITOR
        // Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    void Start()
    {
        playerSprites = GameObject.FindGameObjectsWithTag("Player");
        // Initialize the startingPositions array with the same length as the sprites array
        startingPositions = new Vector3[playerSprites.Length];

        // Store the starting positions of each sprite
        for (int i = 0; i < playerSprites.Length; i++)
        {
            if (playerSprites[i] != null)
            {
                startingPositions[i] = playerSprites[i].transform.position;
            }
        }
        if (sceneName.Equals("PracticeScene"))
            playerChoicePractice();
    }

    // Call this method to respawn all sprites
    public void RespawnSprites()
    {
        foreach (var player in playerSprites)
        {
            // Find the index of the player to get the correct starting position
            int index = System.Array.IndexOf(playerSprites, player);
            if (index != -1)
            {
                player.transform.position = startingPositions[index];
                player.transform.rotation = Quaternion.identity;
                // If your sprites have Rigidbody2D and you want to reset their velocities, uncomment the following line:
                // player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = Vector2.zero;
                    rb.angularVelocity = 0f; // If you also want to reset any rotational velocity
                }
            }
        }
    }
    void DestroyAllWithTag(string tag)
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
    }
}
