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

    private void Update()
    {
        EnterGame();
    }

    void EnterGame()
    {
        if(_enterDoor && Input.GetButtonDown("Item"))
        {
            _sceneObj.GetComponent<SceneManagerScript>()._startCheck = true;
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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _desplayText.text = "";
    }
}
