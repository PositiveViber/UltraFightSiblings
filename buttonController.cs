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
}
