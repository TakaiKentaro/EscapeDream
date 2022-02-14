using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSounds : MonoBehaviour
{
    public AudioSource _audioSource;

    public int _count = 0;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _count++;
            if (_count >= 4)
            {
                _audioSource.Play();
            }
        }
    }
}
