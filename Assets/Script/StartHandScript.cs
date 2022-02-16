using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class StartHandScript : MonoBehaviour
{
    [Header("テキスト")] 
    [SerializeField,Tooltip("スタート画面で出るテキスト")] Text _desplayText;

    [Header("オブジェクト")]
    [SerializeField] GameObject _sceneObj;
    [SerializeField] GameObject _door;
    [SerializeField] GameObject _bed;

    [Header("bool管理")]
    bool _enterDoor;
    bool _sleepBed;

    [Header("カメラ")]
    [SerializeField] GameObject _camera;
    private void Start()
    {
        PauseManager.Instance.PauseEvent += StopLook;
        PauseManager.Instance.PauseEnd += MoveLook;
    }
    private void Update()
    {
        EnterGame();
        SleepBed();
    }

    void EnterGame()
    {
        if(_enterDoor && Input.GetButtonDown("Item"))
        {
            _sceneObj.GetComponent<SceneManagerScript>()._startCheck = true;
            _door.GetComponent<AudioSource>().Play();
            _desplayText.text = "";
        }
    }
    void SleepBed()
    {
        if (_sleepBed && Input.GetButtonDown("Item"))
        {
            _sceneObj.GetComponent<SceneManagerScript>()._goDream = true;
            _bed.GetComponent<AudioSource>().Play();
            _desplayText.text = "";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "EnterDoor":
                _desplayText.text = "”Eキー”入る";
                _enterDoor = true;
                break;
            case "Bed":
                _desplayText.text = "”Eキー”眠る";
                _sleepBed = true;
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _enterDoor = false;
        _sleepBed = false;
        _desplayText.text = "";
    }

    void StopLook()
    {
        _camera.SetActive(false);
    }
    void MoveLook()
    {
        _camera.SetActive(true);
    }
}
