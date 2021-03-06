using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 public class MusicScript : MonoBehaviour
 {
    private AudioSource _audioSource;

    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("Music").Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }
 
    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
            _audioSource.Play();
    }
 
    public void StopMusic()
    {
        _audioSource.Stop();
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
 }