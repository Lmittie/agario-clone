using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer am;
    public AudioSource audioSource;

    public void AudioVolume(float sliderValue)
    {
        am.SetFloat("masterVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void AudioChangeState()
    {
        audioSource.mute = !audioSource.mute;
    }
}
