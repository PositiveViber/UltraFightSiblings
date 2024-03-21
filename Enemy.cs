using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damagePercent = 0; // This represents the accumulated damage

    public void TakeDamage(int damage)
    {
        damagePercent += damage;
    }

    private void Defeat()
    {
        Destroy(gameObject);
    }

    // Add more methods if necessary, like handling knockback calculations based on the damagePercent.
}
