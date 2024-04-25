using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class crystalmaulerCollision : MonoBehaviour
{
    public Animator animator;
    public Transform attackPos;
    public LayerMask enemyLayers;
    public Collider2D[] hitEnemies;
    public float attackRange = 0.0f;
    bool move;

    public Animator enemySprite;

    private knockback KnockBackHandler;

    // Update is called once per frame
    void Update()
    {
        hitEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayers);
        CheckForHit();
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        KnockBackHandler = GetComponent<knockback>();
    }
    void CheckForHit()
    {
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject)
            {

            }
            enemySprite = enemy.gameObject.GetComponent<Animator>();
            if (!enemySprite.GetBool("appliedKnockback"))
            {
                Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
                knockback enemyKnockbackHandler = enemy.GetComponent<knockback>();

                if (enemyRb == null)
                {
                    Debug.Log($"{enemy.gameObject.name} is missing Rigidbody2D");
                    continue;
                }
                if (enemyKnockbackHandler == null)
                {
                    Debug.Log($"{enemy.gameObject.name} is missing knockback handler");
                    continue;
                }

                Debug.Log(enemy.name);





                if (animator.GetBool("isNeutralAiring"))
                {
                    // Perform the action for Neutral Air.
                    // You can further differentiate between Weak and Strong Neutral Air here, if there's a condition to do so.

                    //Applied Damage to character
                    enemySprite.SetInteger("damage", enemySprite.GetInteger("damage") + 8);

                    Vector2 knockbackForce = enemyKnockbackHandler.CalculateKnockback("NeutralAir", transform.position, enemy.transform.position, enemySprite.GetInteger("damage"), 0.6f);
                    // Apply the knockback force
                    enemyRb.AddForce(knockbackForce, ForceMode2D.Impulse);
                    Debug.Log("Complete.");
                }
                else if (animator.GetBool("isUpAiring"))
                {
                    enemySprite.SetInteger("damage", enemySprite.GetInteger("damage") + 9);
                    // Perform the action for Up Air.
                    Vector2 knockbackForce = enemyKnockbackHandler.CalculateKnockback("UpAir", transform.position, enemy.transform.position, enemySprite.GetInteger("damage"), 0.8f);
                    //Applied Damage to character
                    enemySprite.SetInteger("damage", enemySprite.GetInteger("damage") + 8);
                    // Apply the knockback force
                    enemyRb.AddForce(knockbackForce, ForceMode2D.Impulse);
                    Debug.Log("Complete.");
                    // Similarly, differentiate between Weak and Strong Up Air as needed.
                }
                else if (animator.GetBool("isDownAiring"))
                {
                    enemySprite.SetInteger("damage", enemySprite.GetInteger("damage") + 12);
                    // Perform the action for Down Air.
                    Vector2 knockbackForce = enemyKnockbackHandler.CalculateKnockback("DownAir", transform.position, enemy.transform.position, enemySprite.GetInteger("damage"), 0.9f);
                    //Applied Damage to character
                    enemySprite.SetInteger("damage", enemySprite.GetInteger("damage") + 15);
                    // Apply the knockback force
                    enemyRb.AddForce(knockbackForce, ForceMode2D.Impulse);
                    Debug.Log("Complete.");
                    // Differentiate between Weak and Strong Down Air as needed.
                }
                else if (animator.GetBool("isSideAiring"))
                {
                    enemySprite.SetInteger("damage", enemySprite.GetInteger("damage") + 10);
                    // Perform the action for Side Air.
                    Vector2 knockbackForce = enemyKnockbackHandler.CalculateKnockback("SideAir", transform.position, enemy.transform.position, enemySprite.GetInteger("damage"), 0.5f);
                    //Applied Damage to character
                    enemySprite.SetInteger("damage", enemySprite.GetInteger("damage") + 7);
                    // Apply the knockback force
                    enemyRb.AddForce(knockbackForce, ForceMode2D.Impulse);
                    Debug.Log("Complete.");
                    // Differentiate between Weak and Strong Side Air as needed.
                }


                if (animator.GetBool("isNeutralGrounding"))
                {
                    // Perform the action for Neutral Air.
                    // You can further differentiate between Weak and Strong Neutral Air here, if there's a condition to do so.

                    //Applied Damage to character
                    enemySprite.SetInteger("damage", enemySprite.GetInteger("damage") + 16);

                    Vector2 knockbackForce = enemyKnockbackHandler.CalculateKnockback("NeutralGround", transform.position, enemy.transform.position, enemySprite.GetInteger("damage"), 1.0f);
                    // Apply the knockback force
                    enemyRb.AddForce(knockbackForce, ForceMode2D.Impulse);
                    Debug.Log("Complete.");
                }
                else if (animator.GetBool("isSideGrounding"))
                {
                    enemySprite.SetInteger("damage", enemySprite.GetInteger("damage") + 10);
                    // Perform the action for Up Air.
                    Vector2 knockbackForce = enemyKnockbackHandler.CalculateKnockback("SideGround", transform.position, enemy.transform.position, enemySprite.GetInteger("damage"), 0.8f);
                    // Apply the knockback force
                    enemyRb.AddForce(knockbackForce, ForceMode2D.Impulse);
                    Debug.Log("Complete.");
                    // Similarly, differentiate between Weak and Strong Up Air as needed.
                }
                else if (animator.GetBool("isDownGrounding"))
                {
                    enemySprite.SetInteger("damage", enemySprite.GetInteger("damage") + 11);
                    // Perform the action for Down Air.
                    Vector2 knockbackForce = enemyKnockbackHandler.CalculateKnockback("DownGround", transform.position, enemy.transform.position, enemySprite.GetInteger("damage"), 1.1f);
                    // Apply the knockback force
                    enemyRb.AddForce(knockbackForce, ForceMode2D.Impulse);
                    Debug.Log("Complete.");
                    // Differentiate between Weak and Strong Down Air as needed.
                }

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
