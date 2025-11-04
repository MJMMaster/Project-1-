using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Health Settings")]
    public float currentHealth;
    public float maxHealth;
    [Header("visual feedback")]
    public SpriteRenderer spriteRenderer;
    public Color flashColor = Color.red;
    public float flashDuration;
    public UnityEvent<float> onHealthChanged;
    private CameraShake cameraShake;
    public SoundManager soundManager; // drag your SoundManager here in the Inspector
    private Color originalColor;
    private Death deathComponent;

    private void Awake()
    {
        currentHealth = maxHealth;
        cameraShake = Camera.main.GetComponent<CameraShake>();
        onHealthChanged.Invoke(currentHealth / maxHealth);
        deathComponent = GetComponent<Death>();

        if (spriteRenderer == null )
            spriteRenderer = GetComponent<SpriteRenderer>();

        if(spriteRenderer != null )
            originalColor = spriteRenderer.color;
    }
    public void TakeDamage( float amount )
    {
        currentHealth = currentHealth - amount;
        onHealthChanged.Invoke(currentHealth / maxHealth);

        if (spriteRenderer != null)
            StartCoroutine(FlashEffect());
        if (cameraShake != null)
        {
            cameraShake.Shake(0.2f, 0.15f);
        }
        if (soundManager != null)
        {
            soundManager.PlayDamageSound();
        }
        else
        {
            Debug.LogWarning("SoundManager not found on this object!");
        }
        if (CompareTag("Obstacle") && GameManager.Instance.obstacleDamageClip != null)
            if (GameManager.Instance != null && GameManager.Instance.obstacleDamageClip != null)
    {
        AudioSource.PlayClipAtPoint(
            GameManager.Instance.obstacleDamageClip,
            transform.position,
            GameManager.Instance.soundVolume
        );
    }
        if ( !IsAlive() )
        {
            currentHealth = 0;
            Die();
        }
    }

    public void Heal ( float amount )
    {
        currentHealth += amount;
        if ( currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Die()
    {
        Death death = GetComponent<Death>();
        if ( death != null )
        {
            death.Die();
        }
        else
        {
            // If no Death component, just destroy the object or log a warning
            Debug.Log("You dead boi");
            Destroy(gameObject);
        }
    }
    public bool IsAlive()
    {
        if (currentHealth > 0 )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private System.Collections.IEnumerator FlashEffect()
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }
}
