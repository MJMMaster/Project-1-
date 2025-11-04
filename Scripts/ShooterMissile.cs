using UnityEngine;

public class ShooterMissile : Shooter
{
    public GameObject missilePrefab;
    public float missileSpeed = 10f;
    public Transform firePoint;
    public float fireCooldown = 1.5f; // seconds between shots
    private float lastFireTime = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && Time.time > lastFireTime + fireCooldown)
        {
            Shoot();
            lastFireTime = Time.time;
        }
    }

    public override void Shoot()
    {
        if (missilePrefab == null)
            return;

        
        GameObject missile = Instantiate(missilePrefab, transform.position + transform.up * 1.5f, transform.rotation);

        Rigidbody2D rb = missile.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.linearVelocity = transform.up * missileSpeed;

        // Optional sound
        if (GameManager.Instance != null && GameManager.Instance.missileLaunchClip != null)
        {
            AudioSource.PlayClipAtPoint(GameManager.Instance.missileLaunchClip, transform.position, GameManager.Instance.soundVolume);
        }
    }
}