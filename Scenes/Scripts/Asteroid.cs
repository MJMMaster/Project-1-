using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Vector3 direction;


    void Start()
    {
        // Random 2D direction
        direction = Random.insideUnitCircle.normalized;
    }
    void LateUpdate()
    {
        transform.position = GameManager.Instance.WarpPosition(transform.position);
    }

    void Update()
    {
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}