using UnityEngine;
using System.Collections;

public class ObstacleDeath : Death
{
    public AudioSource deathSound;
    public int scoreValue;

    public override void Die()
    {
        // Start the coroutine to handle delayed destruction
        StartCoroutine(PlaySoundAndDestroy());
    }

    private IEnumerator PlaySoundAndDestroy()
    {
        // Unregister the obstacle and add score immediately
        GameManager.Instance.UnregisterObstacle(gameObject);
        GameManager.Instance.AddScore(scoreValue);

        if (deathSound != null && deathSound.clip != null)
        {
            // Detach sound so it can continue playing after object destruction
            deathSound.transform.parent = null;
            deathSound.Play();

            // Wait for the sound to finish
            yield return new WaitForSeconds(deathSound.clip.length);

            // Destroy the sound GameObject after it’s done
            Destroy(deathSound.gameObject);
        }

        // Finally, destroy this object
        Destroy(gameObject);
    }

    void Start()
    {
        GameManager.Instance.RegisterObstacle(gameObject);
    }
}