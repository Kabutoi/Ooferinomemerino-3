using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    public float health = 50f;
    public GameObject Player; 

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die ()
    {
        Destroy(gameObject);
    }

    public void PlayerDie (float amount)
    {
        Destroy(Player);
    }
}
