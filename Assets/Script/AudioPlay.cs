using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public AudioSource _audioSource;

    void Start()
    {
        _audioSource.GetComponent<AudioSource>();
    }

    public void OnClickAudio()
    {
        _audioSource.Play();
    }
}
