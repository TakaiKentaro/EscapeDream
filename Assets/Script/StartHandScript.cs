using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class StartHandScript : MonoBehaviour
{
    [Header("テキスト")] 
    [SerializeField,Tooltip("スタート画面で出るテキスト")] Text _desplayText;

    [Header("シーン移動のオブジェクト")]
    [SerializeField] GameObject _sceneObj;

    [Header("bool管理")]
    bool _enterDoor;
    bool _sleepBed;

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
            _desplayText.text = "";
        }
    }
    void SleepBed()
    {
        if (_sleepBed && Input.GetButtonDown("Item"))
        {
            _sceneObj.GetComponent<SceneManagerScript>()._goDream = true;
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
}
