using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer am;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        float sliderValue = PlayerPrefs.GetFloat("sliderValue", 1.0f);
        Slider slider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        slider.value = sliderValue;
    }

    public void AudioVolume(float sliderValue)
    {
        am.SetFloat("masterVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("sliderValue", sliderValue);
    }

    public void ChangeState()
    {
        _audioSource.mute = !_audioSource.mute;
    }

}
