using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandScripts : MonoBehaviour
{
    [SerializeField] Text _displayText;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Item":
                _displayText.text = "”eキー”アイテムを取る";
                break;
            case "EnterDoor":
                _displayText.text = "”eキー”入る";
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _displayText.text = "";
    }
}
