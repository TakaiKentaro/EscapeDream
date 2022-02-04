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
    [SerializeField] GameObject _flashLight;
    [SerializeField] GameObject _itemManager;
    [SerializeField] GameObject _panel;
    [SerializeField] GameObject _cursorManager;
    [SerializeField] GameObject _camera;
    [SerializeField] GameObject _chest;
    ShowPicture _showPicture;

    bool _takeLight;
    bool _isEnterDoor;
    bool _isOutDoor;
    bool _isItem;
    bool _isChest;
    public bool _moveStop;
    public bool _isPicture;
    Collider _itemCollider;
    Collider _picCollider;
    Collider _lightCollider;
    // Start is called before the first frame update
    private void Start()
    {
        _flashLight.SetActive(false);
        _showPicture = GameObject.FindObjectOfType<ShowPicture>();
    }

    private void Update()
    {
        KeyInput();
        DoorInOut();
        Chest();
        LookImage(_picCollider);
        TakeLight(_lightCollider);
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

    void Chest()
    {
        if (_isChest && Input.GetButtonDown("Item"))
        {
            _cursorManager.GetComponent<CursorManeger>().m_cursor = true;
            _panel.SetActive(true);
            _camera.SetActive(false);
            _moveStop = true;
        }
    }

    void LookImage(Collider other)
    {
        if(_isPicture && Input.GetButtonDown("Item"))
        {
            _cursorManager.GetComponent<CursorManeger>().m_cursor = true;
            _camera.SetActive(false);
            _moveStop = true;
            switch (other.gameObject.name)
            {
                case "Picture1":
                    _showPicture.ShowImage(0);
                    break;
                case "Picture2":
                    _showPicture.ShowImage(1);
                    break;
                case "Picture3":
                    _showPicture.ShowImage(2);
                    break;
            }
        }
    }

    void TakeLight(Collider other)
    {
        if(_takeLight && Input.GetButtonDown("Item"))
        {
            Destroy(other.gameObject);
            _flashLight.SetActive(true);
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
            case "Chest":
                //if (_chest.GetComponent<TresureChest>()._letOpen == true) break;
                _displayText.text = "”Eキー”開ける";
                _isChest = true;
                break;
            case "Picture":
                _displayText.text = "”Eキー”見る";
                _isPicture = true;
                _picCollider = other;
                break;
            case "FlashLight":
                _displayText.text = "”Eキー”手に持つ";
                _takeLight = true;
                _lightCollider = other;
                break;
        }
    }

    public void OnBackButon()
    {
        _displayText.text = "";
        _isEnterDoor = false;
        _isItem = false;
        _itemCollider = null;
        _isChest = false;
        _panel.SetActive(false);
        _cursorManager.GetComponent<CursorManeger>().m_cursor = false;
        _camera.SetActive(true);
        _moveStop = false;
        _isPicture = false;
        _showPicture.ResetImage();
    }

    void ResetText()
    {
        _displayText.text = "";
        _isEnterDoor = false;
        _isItem = false;
        _itemCollider = null;
        _isChest = false;
        _panel.SetActive(false);
        _cursorManager.GetComponent<CursorManeger>().m_cursor = false;
        //_camera.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        _displayText.text = "";
        _isEnterDoor = false;
        _isItem = false;
        _itemCollider = null;
        _isChest = false;
        _panel.SetActive(false);
        _isPicture = false;
        _cursorManager.GetComponent<CursorManeger>().m_cursor = false;
        _takeLight = false;
        //_camera.SetActive(true);
    }
}
