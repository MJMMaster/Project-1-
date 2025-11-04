using UnityEngine;

public class DamageOnOverlap : MonoBehaviour
{
    [Header("Damage Settings")]
    public float damageDone = 10f;
    public bool instantKill = false; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        

        // Check if the other object has a Health component
        Health otherHealth = other.gameObject.GetComponent<Health>();
        if (otherHealth != null)
        {
            if (instantKill)
            {
                // If instant kill is true, skip damage and kill the target
                otherHealth.Die();
            }
            else
            {
                // Otherwise, deal normal damage
                otherHealth.TakeDamage(damageDone);
            }
        }
    }
}