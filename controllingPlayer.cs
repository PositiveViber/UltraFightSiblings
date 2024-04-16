using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllingPlayer : MonoBehaviour
{
    public int lives = 3;

    private Vector3 startingPosition;
    private Quaternion startingRotation;

    void Start()
    {
        // Store the initial position and rotation
        startingPosition = transform.position;
        startingRotation = transform.rotation;
    }

    public void Respawn()
    {
        if (lives > 0)
        {
            transform.position = startingPosition;
            transform.rotation = startingRotation;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }
            lives--; // Decrement lives
        }
        else
        {
            // Handle the player running out of lives (e.g., disable player control)
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Example check for falling off the stage
        if (transform.position.y < -10) // Assuming -10 is the fall threshold
        {
            Respawn();
        }
    }
}
