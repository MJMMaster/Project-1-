using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    // ---------- Singleton Pattern ----------
    public static GameManager Instance { get; private set; }
    
   
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
    }

 



    // ---------- Game Logic ----------
    [Header("Game Tracking")]
    public int totalObstacles;
    public List<GameObject> activeObstacles = new List<GameObject>();
    private bool playerIsAlive = true;

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
    }
    public int score = 0;
    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }
}