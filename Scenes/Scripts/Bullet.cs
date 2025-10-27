using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float speed = 10f;
    public float lifetime = 3f;
    public float damage = 1f;

    private float lifeTimer;

    void Update()
    {
        // Move forward each frame (in local space)
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);

        // Count lifetime using deltaTime
        lifeTimer += Time.deltaTime;

        // Destroy after timer expires
        if (lifeTimer >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Optional: deal damage if object has health
        Health targetHealth = other.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
        }

        // Destroy bullet on contact
        Destroy(gameObject);
    }
}
