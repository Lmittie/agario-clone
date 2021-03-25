using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer am;
    private AudioSource _audioSource;
    private float _sliderValue;

    private void Start()
    {
        _audioSource = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        _sliderValue = PlayerPrefs.GetFloat("sliderValue", 0.5f);
        Slider slider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        slider.value = _sliderValue;
    }

    public void AudioVolume(float sliderValue)
    {
        am.SetFloat("masterVolume", Mathf.Log10(sliderValue) * 20);
        _sliderValue = sliderValue;
    }

    public void ChangeState()
    {
        _audioSource.mute = !_audioSource.mute;
    }

    public void OnDestroy()
    {
        PlayerPrefs.SetFloat("sliderValue", _sliderValue);
    }
}
