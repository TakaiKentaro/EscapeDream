using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandScripts : MonoBehaviour
{
    [SerializeField] Text _displayText;
    [SerializeField] GameObject _sceneManager;
    bool _isArea;
    bool _isItem;
    // Start is called before the first frame update
    private void Start()
    {
        _sceneManager = GameObject.Find("SceneManager");
    }

    private void Update()
    {
        KeyInput();
    }

    void KeyInput()
    {
        if(_isArea)
        {
            if (Input.GetButtonDown("Item"))
            {
                Debug.Log("aaa");
                _sceneManager.GetComponent<SceneManagerScript>().DoFadeImageIn(1f);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Item":
                _displayText.text = "”eキー”アイテムを取る";
                _isItem = true;
                break;
            case "EnterDoor":
                _displayText.text = "”eキー”入る";
                _isArea = true;
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _displayText.text = "";
        _isArea = false;
        _isItem = false;
    }
}
