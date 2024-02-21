using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolumeSlider : MonoBehaviour
{
    public AudioMixer audioMixer;
    public string volumeParameter = "MasterVolume";
    public AudioSource audioSource;

    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void Start()
    {
        // Load the previously saved volume level
        float savedVolume = PlayerPrefs.GetFloat(volumeParameter, 1f);
        slider.value = savedVolume;
        ChangeVolume(savedVolume);
    }

    private void ChangeVolume(float volume)
    {
        audioMixer.SetFloat(volumeParameter, Mathf.Log10(volume) * 20f);

        // Set the volume of the audio source
        audioSource.volume = volume;

        // Save the volume level for future sessions
        PlayerPrefs.SetFloat(volumeParameter, volume);
        PlayerPrefs.Save();
    }
}
