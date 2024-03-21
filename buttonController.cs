using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonController : MonoBehaviour
{
    public string sceneName; // Assign the name of the scene you want to load in the Inspector

    public void Activate()
    {
        // Load the scene with the given name
        Debug.Log("Attempting to load scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
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
}
