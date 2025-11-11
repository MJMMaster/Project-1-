using UnityEngine;

public class DeathDestroy : Death
{
    public AudioClip deathSound;

    public override void Die()
    {
        // Play 3D sound at object position
        if (deathSound != null)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position, GameManager.Instance.soundVolume);
        }

        // Add score
        GameManager.Instance.AddScore(50);

        // Unregister from GameManager if needed
        GameManager.Instance.UnregisterObstacle(gameObject);

        // Destroy the object
        Destroy(gameObject);
    }
}