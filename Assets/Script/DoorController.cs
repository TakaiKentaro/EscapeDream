using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _anim.SetBool("OpenDoor",true);
        }
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
