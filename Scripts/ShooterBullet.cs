using UnityEngine;

public class ShooterBullet : Shooter
{
    public Transform firePoint; // Set to the ship�s nose in the inspector

    public override void Shoot()
    {
        if (projectilePrefab == null || firePoint == null)
        {
            Debug.LogWarning("ShooterBullet missing prefab or fire point!");
            return;
        }

        // Spawn projectile 1 unit in front of the ship
        Vector3 spawnPos = firePoint.position + firePoint.up * 1f;
        GameObject proj = Instantiate(projectilePrefab, spawnPos, firePoint.rotation);

        // Give it forward velocity
        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.up * projectileSpeed;
        }
    }
}