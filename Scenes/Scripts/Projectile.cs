using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Damage Settings")]
    public float damage = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health targetHealth = other.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
        }

        // Optional: prevent damaging the shooter or same team
        Destroy(gameObject); // Destroy projectile on impact
    }
}