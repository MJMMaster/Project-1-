using UnityEngine;
using System.Collections;

public class ObstacleDeath : Death
{
    [Header("Optional Death Sound")]
    public AudioSource deathSound;

    [Header("Score Value")]
    public int scoreValue = 100;

    private bool hasDied = false;
    [Header("Asteroid Split Settings")]
    public bool isAsteroid = false;                  // Enable splitting
    public GameObject smallerAsteroidPrefab;         // Prefab to spawn
    public int spawnCount = 2;                       // How many to spawn on death
    public float spawnOffset = 0.5f;                 // How far from center to spawn
    public float spawnForce = 2f;                    // Push force applied to new asteroids

    private void Start()
    {
        GameManager.Instance.RegisterObstacle(gameObject);
    }

    public override void Die()
    {
        if (hasDied) return;   
        hasDied = true;
        StartCoroutine(PlaySoundAndDestroy());
    }

    private IEnumerator PlaySoundAndDestroy()
    {
        //  Score first
        GameManager.Instance.AddScore(scoreValue);

        //  Spawn new children BEFORE unregistering this asteroid
        RegisterSpawnedAsteroids();

        //  NOW safe to unregister this asteroid
        GameManager.Instance.UnregisterObstacle(gameObject);

        if (deathSound != null && deathSound.clip != null)
        {
            deathSound.transform.parent = null;
            deathSound.Play();

            yield return new WaitForSeconds(deathSound.clip.length);
            Destroy(deathSound.gameObject);
        }

        Destroy(gameObject);

        Debug.Log("Asteroid died + spawned children: " + gameObject.name);
    }


    private void RegisterSpawnedAsteroids()
    {
        if (smallerAsteroidPrefab == null)
        {
            Debug.LogWarning("No small asteroid prefab assigned!");
            return;
        }

        for (int i = 0; i < 2; i++)
        {
            Vector3 offset = Random.insideUnitCircle.normalized * 1.0f;
            GameObject newAst = Instantiate(smallerAsteroidPrefab, transform.position + offset, Quaternion.identity);

            //  Make sure new obstacles are registered in GameManager
            GameManager.Instance.RegisterObstacle(newAst);
        }
    }
    
}