using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public Slider soundSlider;
    public Slider musicSlider;

    void Start()
    {
        // Load settings from PlayerPrefs directly
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 1f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);

        soundSlider.onValueChanged.AddListener(UpdateSoundVolume);
        musicSlider.onValueChanged.AddListener(UpdateMusicVolume);
    }

    public void UpdateSoundVolume(float value)
    {
        PlayerPrefs.SetFloat("SoundVolume", value);
        AudioListener.volume = value;   // live update
    }

    public void UpdateMusicVolume(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }

}