using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    private Animator animator;
    public Transform attackPos;
    public LayerMask enemyLayers;
    public Collider2D[] hitEnemies;
    public float attackRange = 0.0f;
    bool move;


    // Update is called once per frame
    void Update()
    {
        hitEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayers);
        CheckForHit();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void CheckForHit()
    {
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name);
            if (animator.GetBool("isNeutralAiring"))
            {
                // Perform the action for Neutral Air.
                // You can further differentiate between Weak and Strong Neutral Air here, if there's a condition to do so.
            }
            else if (animator.GetBool("isUpAiring"))
            {
                // Perform the action for Up Air.
                // Similarly, differentiate between Weak and Strong Up Air as needed.
            }
            else if (animator.GetBool("isDownAiring"))
            {
                // Perform the action for Down Air.
                // Differentiate between Weak and Strong Down Air as needed.
            }
            else if (animator.GetBool("isSideAiring"))
            {
                // Perform the action for Side Air.
                // Differentiate between Weak and Strong Side Air as needed.
            }
            // Add more conditions here if there are more moves.
            else
            {

            }
        }
        
    }
    void OnDrawGizmosSelected()
    {
        if (attackPos == null)
            return;

        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
