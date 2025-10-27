using UnityEngine;

public class ObstacleDeath : Death
{
    public int scoreValue;
    public override void Die()
    {
        GameManager.Instance.UnregisterObstacle(gameObject);
        Destroy(gameObject);
        GameManager.Instance.AddScore(scoreValue);
    }

    void Start()
    {
        GameManager.Instance.RegisterObstacle(gameObject);
    }
}