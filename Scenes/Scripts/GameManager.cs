using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ---------- Singleton Pattern ----------
    public static GameManager Instance { get; private set; }

    [Header("Audio Settings")]
    public AudioClip obstacleDamageClip;
    public AudioClip missileLaunchClip;
    public AudioClip missileImpactClip;

    [Header("Persistent Settings")]
    [Range(0f, 1f)] public float soundVolume = 1f;
    [Range(0f, 1f)] public float musicVolume = 1f;

    void Awake()
    {
        // Ensure only one instance exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadSettings();
    }


    // ---------- Game Tracking ----------
    [Header("Game Tracking")]
    public int totalObstacles;
    public List<GameObject> activeObstacles = new List<GameObject>();
    private bool playerIsAlive = true;

    public int score = 0;

    public void RegisterObstacle(GameObject obstacle)
    {
        if (!activeObstacles.Contains(obstacle))
        {
            activeObstacles.Add(obstacle);
            totalObstacles = activeObstacles.Count;
        }
    }

    public void UnregisterObstacle(GameObject obstacle)
    {
        if (activeObstacles.Contains(obstacle))
        {
            activeObstacles.Remove(obstacle);
            totalObstacles = activeObstacles.Count;

            if (totalObstacles == 0)
            {
                Debug.Log("Victory!");
                
                    // If asteroids don't spawn more
                    SceneManager.LoadScene("Victory");
                
            }
        }
    }

    public void PlayerDied()
    {
        if (playerIsAlive)
        {
            playerIsAlive = false;
            Debug.Log("Failure!");
        }
        SceneManager.LoadScene("Main Menu");
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }


    // ---------- Settings Persistence ----------
    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("soundVolume", soundVolume);
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.Save();
    }

    public void ApplyVolume()
    {
        AudioListener.volume = soundVolume;
    }


    public void LoadSettings()
    {
        soundVolume = PlayerPrefs.GetFloat("soundVolume", 1f);
        musicVolume = PlayerPrefs.GetFloat("musicVolume", 1f);
        ApplyVolume();
    }



    // ---------- Enemy Spawning ----------
    [Header("Enemy Spawning")]
    public int enemyCount = 10;
    [Range(0f, 1f)]
    public float ufoChance = 0.3f;

    public GameObject ufoPrefab;
    public GameObject asteroidPrefab;

    [Tooltip("Area where enemies can spawn")]
    public Vector2 spawnMin = new Vector2(-10f, -5f);
    public Vector2 spawnMax = new Vector2(10f, 5f);

    void Start()
    {
        SpawnEnemies();
        UpdateBoundsFromCamera();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            bool spawnUFO = Random.value < ufoChance;
            Vector3 spawnPos = GetRandomSpawnPoint();

            if (spawnUFO && ufoPrefab != null)
            {
                Instantiate(ufoPrefab, spawnPos, Quaternion.identity);
            }
            else if (asteroidPrefab != null)
            {
                Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
            }
        }
    }

    Vector3 GetRandomSpawnPoint()
    {
        float x = Random.Range(spawnMin.x, spawnMax.x);
        float y = Random.Range(spawnMin.y, spawnMax.y);
        return new Vector3(x, y, 0f);
    }


    // ---------- Screen Warp ----------
    [Header("Screen Warp Bounds")]
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public Vector2 WarpPosition(Vector2 pos)
    {
        if (pos.x > maxX) pos.x = minX;
        else if (pos.x < minX) pos.x = maxX;

        if (pos.y > maxY) pos.y = minY;
        else if (pos.y < minY) pos.y = maxY;

        return pos;
    }

    public void UpdateBoundsFromCamera()
    {
        Camera cam = Camera.main;

        if (cam == null) return;

        float height = cam.orthographicSize;
        float width = height * cam.aspect;

        minX = -width;
        maxX = width;
        minY = -height;
        maxY = height;
    }
}