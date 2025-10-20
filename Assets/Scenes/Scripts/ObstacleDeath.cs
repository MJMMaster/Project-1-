using UnityEngine;

public class ObstacleDeath : Death
{
    public override void Die()
    {
        GameManager.Instance.UnregisterObstacle(gameObject);
        Destroy(gameObject);
        GameManager.Instance.AddScore(100);
    }

    void Start()
    {
        GameManager.Instance.RegisterObstacle(gameObject);
    }
}