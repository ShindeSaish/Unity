using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 50;

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Dead");
        Destroy(gameObject);
    }
}
