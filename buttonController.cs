using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonController : MonoBehaviour
{
    playerMovement playerMovement;
    public string sceneName; // Assign the name of the scene you want to load in the Inspector
    public GameObject[] sprites; // Assign your sprite GameObjects in the inspector
    private GameObject[] playerSprites;
    private Vector3[] startingPositions;
    public string characterChoice1;
    public string characterChoice2;
    public static bool knightPicked = false;
    public static bool warriorPicked = false;
    public static bool bladekeeperPicked = false;
    public static bool maulerPicked = false;
    public void Activate()
    {
        // Load the scene with the given name
        Debug.Log("Attempting to load scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void playerChoiceMainGame()
    {
        if (characterChoice1.Equals("knight") && characterChoice2.Equals("crystalmauler"))
        {
            knightPicked = !knightPicked;
            DestroyAllWithTag("bladekeeper");

        }
        else if (characterChoice1.Equals("warrior") && characterChoice2.Equals("crystalmauler"))
        {
            warriorPicked = !warriorPicked;
        }
        else if (characterChoice1.Equals("bladekeeper") && characterChoice2.Equals("crystalmauler"))
        {
            bladekeeperPicked = !bladekeeperPicked;

        }
        else if (characterChoice1.Equals("crystalmauler") && characterChoice2.Equals("crystalmauler"))
        {
            maulerPicked = !maulerPicked;
        }



        if (characterChoice1.Equals("knight") && characterChoice2.Equals("knight"))
        {
            knightPicked = !knightPicked;
            DestroyAllWithTag("bladekeeper");

        }
        else if (characterChoice1.Equals("warrior") && characterChoice2.Equals("knight"))
        {
            warriorPicked = !warriorPicked;
        }
        else if (characterChoice1.Equals("bladekeeper") && characterChoice2.Equals("knight"))
        {
            bladekeeperPicked = !bladekeeperPicked;

        }
        else if (characterChoice1.Equals("crystalmauler") && characterChoice2.Equals("knight"))
        {
            maulerPicked = !maulerPicked;
        }


        if (characterChoice1.Equals("knight") && characterChoice2.Equals("warrior"))
        {
            knightPicked = !knightPicked;
            DestroyAllWithTag("bladekeeper");

        }
        else if (characterChoice1.Equals("warrior") && characterChoice2.Equals("warrior"))
        {
            warriorPicked = !warriorPicked;
        }
        else if (characterChoice1.Equals("bladekeeper") && characterChoice2.Equals("warrior"))
        {
            bladekeeperPicked = !bladekeeperPicked;

        }
        else if (characterChoice1.Equals("crystalmauler") && characterChoice2.Equals("warrior"))
        {
            maulerPicked = !maulerPicked;
        }


        if (characterChoice1.Equals("knight") && characterChoice2.Equals("knight"))
        {
            knightPicked = !knightPicked;
            DestroyAllWithTag("bladekeeper");

        }
        else if (characterChoice1.Equals("warrior") && characterChoice2.Equals("knight"))
        {
            warriorPicked = !warriorPicked;
        }
        else if (characterChoice1.Equals("bladekeeper") && characterChoice2.Equals("knight"))
        {
            bladekeeperPicked = !bladekeeperPicked;

        }
        else if (characterChoice1.Equals("crystalmauler") && characterChoice2.Equals("knight"))
        {
            maulerPicked = !maulerPicked;
        }

    }
    public void playerChoicePractice()
    {
        if (characterChoice1.Equals("knight"))
        {
            knightPicked = !knightPicked;
        }
        if (characterChoice1.Equals("warrior"))
        {
            warriorPicked = !warriorPicked;
        }
        if (characterChoice1.Equals("bladekeeper"))
        {
            bladekeeperPicked = !bladekeeperPicked;

        }
        if (characterChoice1.Equals("crystalmauler"))
        {
            maulerPicked = !maulerPicked;
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
        playerMovement.LoadSpriteData();

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
