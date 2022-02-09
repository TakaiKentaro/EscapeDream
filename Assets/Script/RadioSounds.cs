using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSounds : MonoBehaviour
{
    AudioSource _audioSource;

    public int _count = 0;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "FlashLight")
        {
            _count++;
            Debug.Log(_count);
            if (_count >= 3)
            {
                _audioSource.PlayOneShot(_audioSource.clip);
            }
        }
    }
}
