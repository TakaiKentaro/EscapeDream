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
    [SerializeField] GameObject _radio;

    [Header("bool管理")]
    bool _enterDoor;
    bool _sleepBed;
    bool _stopRadio;

    
    private void Update()
    {
        EnterGame();
        SleepBed();
        StopRadio();
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
    bool check = false;
    void StopRadio()
    {
        if (_stopRadio && Input.GetButtonDown("Item") && !check)
        {

            _radio.GetComponent<AudioSource>().Stop();
            check = true;
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
            case "Radio":
                if (check) return;
                _desplayText.text = "”Eキー”止める";
                _stopRadio = true;
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _enterDoor = false;
        _sleepBed = false;
        _stopRadio = false;
        _desplayText.text = "";
    }
}
