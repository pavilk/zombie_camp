using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettingsUI : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider sfxSlider;

    private void Start()
    {
        if (audioMixer.GetFloat("SFXVolume", out float value))
            sfxSlider.value = value;

        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetSFXVolume(float value)
    {
        audioMixer.SetFloat("SFXVolume", value);
    }
}
