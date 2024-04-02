using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class knockback : MonoBehaviour
{
    public Vector2 previousForce;
    public Vector2 force = new Vector2 (0.0f, 0.0f);
    Animator animator;

    // Example method to calculate knockback
    public Vector2 CalculateKnockback(string move, Vector3 attackerPosition, Vector3 enemyPosition)
    {
        float forceMagnitude = DetermineForceByMove(move);
        Vector2 knockbackDirection = (enemyPosition - attackerPosition).normalized;

        switch (move)
        {
            case "NeutralAir":
                // For a neutral air, you might want to knock the enemy slightly upwards and away
                knockbackDirection += Vector2.up * .5f; // Adjust the multiplier to get the desired angle
                break;
            case "SideAir":
                // For an uppercut, you would want a stronger upward force
                knockbackDirection += (Vector2.up * .5f); // Weight more heavily towards 'up'
                break;
            case "UpAir":
                knockbackDirection += Vector2.Lerp(knockbackDirection, Vector2.up, 4f); // Weight more heavily towards 'up'
                break;
            case "DownAir":
                knockbackDirection += Vector2.Lerp(knockbackDirection, Vector2.up, .75f); // Weight more heavily towards 'up'
                break; 
            case "DownGround":
                break;
            case "NeutralGround":
                break;
            case "SideGround":
                break;
                // Add other cases as necessary
        }

        // Normalize the direction after adjustment
        knockbackDirection.Normalize();

        force = knockbackDirection * forceMagnitude;
        animator.SetBool("appliedKnockback", true);
        previousForce = force;
        Debug.Log($"Knockback force calculated: {force}");
        

        return force;
    }

     void Start()
    {
        animator = GetComponent<Animator>();
    }
     void Update()
    {
        calculateForce();
        if (animator.GetBool("appliedKnockback"))
        {
            if((Math.Abs(previousForce.x + previousForce.y))/2  > Math.Abs(force.x + force.y))
            {
                animator.SetBool("appliedKnockback", false);
                force = new Vector2 (0.0f, 0.0f);
            }
        }
    }

    private float DetermineForceByMove(string move)
    {
        switch (move)
        {
            case "NeutralAir":
                return 1.5f; // Some arbitrary force value
            case "SideAir":
                return 1.3f;
            case "UpAir":
                return 5.1f;
            case "DownAir":
                return 0.7f;
            case "DownGround":
                return 1.0f;
            case "NeutralGround":
                return 0.5f;
            case "SideGround":
                return 0.3f;
            default:
                return 0f;
        }
    }

    void calculateForce ()
    {
        force = force * .99f;
    }
}
