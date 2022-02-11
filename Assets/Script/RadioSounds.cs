using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSounds : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("あたった");
        }
    }
}
