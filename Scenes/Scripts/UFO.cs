using UnityEngine;

public class UFO : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Transform player;

    void Start()
    {
        if (GameObject.FindWithTag("Player") != null)
            player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    void LateUpdate()
    {
        transform.position = GameManager.Instance.WarpPosition(transform.position);
    }
}