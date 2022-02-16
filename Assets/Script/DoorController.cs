﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    Animator _anim;

    [Header("ライト")]
    [SerializeField] GameObject _light;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_light.activeSelf)
        {
            if (other.gameObject.tag == "Player")
            {
                _anim.SetBool("OpenDoor", true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("CloseDoor");
        }
    }

    IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(2);
        _anim.SetBool("OpenDoor", false);
    }
}
