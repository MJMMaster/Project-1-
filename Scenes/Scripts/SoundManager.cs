using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource audioSource; // Reference to the audio source component

    [Header("Sound Effects")]
    public AudioClip shootSound;
    public AudioClip damageSound;
    public AudioClip deathSound;

    [Header("Persistent Settings")]
    [Range(0f, 1f)] public float soundVolume = 1f;
    [Range(0f, 1f)] public float musicVolume = 1f;

    // Plays a specific clip one time

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("soundVolume", soundVolume);
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.Save();
    }

    public void ApplyVolume()
    {
        AudioListener.volume = soundVolume;
    }


    public void LoadSettings()
    {
        soundVolume = PlayerPrefs.GetFloat("soundVolume", 1f);
        musicVolume = PlayerPrefs.GetFloat("musicVolume", 1f);
        ApplyVolume();
    }
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