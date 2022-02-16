using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayerScript : MonoBehaviour
{
    [SerializeField] float _speed;
    Rigidbody _rb;

    [SerializeField] AudioSource _audio;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal") * _speed;
        float v = Input.GetAxisRaw("Vertical") * _speed;
        Vector3 dir = new Vector3(h, 0, v);
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;
        _rb.velocity = dir.normalized * _speed + _rb.velocity.y * Vector3.up;
        if(Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            _audio.Play();
        }
        if(Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {
            _audio.Stop();
        }
    }
}
