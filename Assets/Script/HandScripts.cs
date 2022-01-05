using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandScripts : MonoBehaviour
{
    [Header("テキスト")]
    [SerializeField] Text _displayText;
    
    [Header("シーン移動のscript")]
    [SerializeField] GameObject _sceneManager;

    [Header("アイテム管理")]
    [SerializeField] GameObject _itemManager;

    bool _isEnterDoor;
    bool _isOutDoor;
    bool _isItem;
    Collider _itemCollider;
    // Start is called before the first frame update
    private void Start()
    {
        _sceneManager = GameObject.Find("SceneManager");
        _itemManager = GameObject.Find("ItemCheck");
    }

    private void Update()
    {
        KeyInput();
        DoorInOut();
    }

    void KeyInput()
    {
        if(_isItem)
        {
            if(Input.GetButtonDown("Item") && _itemManager.GetComponent<ItemManager>()._isKey == false)
            {
                _displayText.text = "鍵を取った";
                _itemManager.GetComponent<ItemManager>()._isKey = true;
                Destroy(_itemCollider.gameObject);
                Invoke(nameof(ResetText), 2);
            }
        }
    }
    void DoorInOut()
    {
        if (_isEnterDoor && Input.GetButtonDown("Item"))
        {
            _sceneManager.GetComponent<SceneManagerScript>().DoFadeImageIn(1f);
        }

        if (_isOutDoor && Input.GetButtonDown("Item"))　//ドアを出る
        {
            if (_itemManager.GetComponent<ItemManager>()._isKey == true) //鍵を持っているかを判定
            {
                _sceneManager.GetComponent<SceneManagerScript>().DoFadeImageIn(1f);
            }
            else
            {
                _displayText.text = "鍵がない";
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Key":
                _displayText.text = "”Eキー”アイテムを取る";
                _isItem = true;
                _itemCollider = other;
                break;
            case "EnterDoor":
                _displayText.text = "”Eキー”入る";
                _isEnterDoor = true;
                break;
            case "OutDoor":
                _displayText.text = "”Eキー”出る";
                _isOutDoor = true;
                break;
        }
    }

    void ResetText()
    {
        _displayText.text = "";
        _isEnterDoor = false;
        _isItem = false;
        _itemCollider = null;
    }

    private void OnTriggerExit(Collider other)
    {
        _displayText.text = "";
        _isEnterDoor = false;
        _isItem = false;
        _itemCollider = null;
    }
}
