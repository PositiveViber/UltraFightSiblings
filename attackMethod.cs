using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMethod : MonoBehaviour
{
    public float startTimeAttack;
    private float timeBtwAttack;

    public Transform attackPos;
    public LayerMask enemiesLayer;
    public float attackRange;
    public int damage;
    public float knockbackForce;

    private void Update()
    {
        if (timeBtwAttack <= 0)
        {
            // You can attack
            if (Input.GetKeyDown(KeyCode.Space)) // Assuming space is your attack key
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemiesLayer);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage); // Ensure your enemy has a TakeDamage method
                    // Apply Knockback
                    Rigidbody2D enemyRb = enemiesToDamage[i].GetComponent<Rigidbody2D>();
                    if (enemyRb != null)
                    {
                        Vector2 direction = enemyRb.transform.position - transform.position;
                        enemyRb.AddForce(direction.normalized * knockbackForce, ForceMode2D.Impulse);
                    }
                }
                timeBtwAttack = startTimeAttack;
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPos == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
