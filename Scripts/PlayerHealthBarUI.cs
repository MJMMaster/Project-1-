using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarUI : MonoBehaviour
{
    public Image fillImage;
    public Health playerHealth;

    void Start()
    {
        if (playerHealth != null)
        {
            playerHealth.onHealthChanged.AddListener(UpdateHealthBar);
        }
    }

    void UpdateHealthBar(float normalizedValue)
    {
        fillImage.fillAmount = normalizedValue;
    }
}