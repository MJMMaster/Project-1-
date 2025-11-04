using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    private SpriteRenderer theRenderer;
    public KeyCode keyToUse;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theRenderer = this.gameObject.GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToUse))
        {
            // change the sprite colors
            Color newColor = new Color(Random.Range(0.0f,1.0f), Random.Range(0.0f,1.0f), Random.Range(0.0f,1.0f), 1.0f);
            theRenderer.color = newColor;
        }
    }
}
