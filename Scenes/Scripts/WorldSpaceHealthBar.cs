using UnityEngine;
using UnityEngine.UI;

public class WorldSpaceHealthBar : MonoBehaviour
{
    public Image fillImage; // assign this in inspector
    private Health health;  // reference to the parent’s Health component

    void Start()
    {
        // get health from parent object
        health = GetComponentInParent<Health>();
    }

    void Update()
    {
        if (health != null && fillImage != null)
        {
            float healthPercent = health.currentHealth / health.maxHealth;
            fillImage.fillAmount = Mathf.Clamp01(healthPercent);
        }

        // Optional: make bar always face the camera
        if (Camera.main != null)
        {
            transform.LookAt(Camera.main.transform);
            transform.Rotate(0, 180, 0); // correct facing direction
        }
    }
}