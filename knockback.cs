using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class knockback : MonoBehaviour
{
    public Vector2 previousForce;
    public Vector2 force = new Vector2 (0.0f, 0.0f);
    Animator animator;
    public static int playerDamage;

    // Example method to calculate knockback
    public Vector2 CalculateKnockback(string move, Vector3 attackerPosition, Vector3 enemyPosition, int damage, float multiplier)
    {
        float forceMagnitude = DetermineForceByMove(damage, multiplier);
        Vector2 knockbackDirection = (enemyPosition - attackerPosition).normalized;

        switch (move)
        {
            case "NeutralAir":
                // For a neutral air, you might want to knock the enemy slightly upwards and away
                knockbackDirection += (Vector2.up  * .5f); // Adjust the multiplier to get the desired angle
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
        playerDamage = animator.GetInteger("damage");
    }

    private float DetermineForceByMove(int damage, float multiplier)
    {
        return (damage/4.5f) * multiplier;
    }

    public int showDamage()
    {
        return animator.GetInteger("damage");
    }
    void calculateForce ()
    {
        force = force * .99f;
    }

    void setAttacksFalse ()
    {
        if (animator.GetBool("isAttacking"))
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("isDownGrounding", false);
            animator.SetBool("isDownAiring", false);
            animator.SetBool("isNeutralAiring", false);
            animator.SetBool("isUpAiring", false);
            animator.SetBool("isSideGrounding", false);
            animator.SetBool("isNeutralGrounding", false);
            animator.SetBool("isGroundGuarding", false);
            animator.SetBool("isAirGuarding", false);
            animator.SetBool("isSideAiring", false);
        }
    }
}
