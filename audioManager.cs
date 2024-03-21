using UnityEngine;
using UnityEngine.SceneManagement;

public class audioManager : MonoBehaviour
{
    public AudioClip[] music; // Array to hold your music tracks
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event
    }


    private void PlayMusic(int index)
    {
        if (index >= 0 && index < music.Length)
        {
            audioSource.clip = music[index];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Invalid music index.");
        }
    }
}
