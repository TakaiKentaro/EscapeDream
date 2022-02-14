using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    [Header("プレイヤーのスピード")]
    [SerializeField] float _speed;

    [Header("SceneManager")]
    [SerializeField] GameObject _sceneManager;

    void Update()
    {
        transform.position += new Vector3(0, 0, _speed) * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("WarpPoint"))
        {
            _sceneManager.GetComponent<SceneManagerScript>()._check = true;
        }
    }
}
