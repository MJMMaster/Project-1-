using UnityEngine;

public class SpriteScaler : MonoBehaviour
{
    public KeyCode toUseKey;
    private Transform move;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(toUseKey))
        {
            if (move != null)
            {
                move.position = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), 0.0f);
            }
        }
    }
}
