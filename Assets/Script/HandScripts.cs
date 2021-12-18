using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandScripts : MonoBehaviour
{
    [SerializeField] Text _displayText;
    [SerializeField] GameObject _sceneManager;
    [SerializeField] GameObject _itemMannegement;

    bool _isArea;
    bool _isItem;
    // Start is called before the first frame update
    private void Start()
    {
        _sceneManager = GameObject.Find("SceneManager");
        _itemMannegement = GameObject.Find("ItemCheck");
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
                _sceneManager.GetComponent<SceneManagerScript>().DoFadeImageIn(1f);
            }
        }
        if(_isItem)
        {
            if(Input.GetButtonDown("Item"))
            {
                _displayText.text = "アイテムを取った";
                _itemMannegement.GetComponent<ItemmanagementScript>()._keyCheck = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Item":
                _displayText.text = "”Eキー”アイテムを取る";
                _isItem = true;
                break;
            case "EnterDoor":
                _displayText.text = "”Eキー”入る";
                _isArea = true;
                break;
            case "OutDoor":
                _displayText.text = "”Eキー”出る";
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
