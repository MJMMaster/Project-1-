using UnityEngine;

public class MissileProjectile : MonoBehaviour
{
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health targetHealth = other.GetComponent<Health>();
        if (targetHealth != null)
        {
            
                targetHealth.TakeDamage(9999); // fallback

            // Explosion sound or effect
            if (GameManager.Instance != null && GameManager.Instance.missileImpactClip != null)
            {
                AudioSource.PlayClipAtPoint(GameManager.Instance.missileImpactClip, transform.position, GameManager.Instance.soundVolume);
            }

            Destroy(gameObject);
        }
    }
}