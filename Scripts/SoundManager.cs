using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource audioSource; // Reference to the audio source component

    [Header("Sound Effects")]
    public AudioClip shootSound;
    public AudioClip damageSound;
    public AudioClip deathSound;

    // Plays a specific clip one time
    public void PlayShootSound()
    {
        PlaySound(shootSound);
    }

    public void PlayDamageSound()
    {
        PlaySound(damageSound);
    }

    public void PlayDeathSound()
    {
        PlaySound(deathSound);
    }

    // Reusable private helper
    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}