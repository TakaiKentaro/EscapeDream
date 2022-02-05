using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockPanelScript : MonoBehaviour
{
    [Header("パネルについているボタンを入れる")]
    [SerializeField] Button[] _buttons;

    [Header("Stoneがあった時に切り替える画像")]
    [SerializeField] Sprite[] _sprits;

    [Header("Stoneがあるかの判定をとる")]
    [Tooltip("maruがあるかのチェック")] public bool _maruCheck;
    [Tooltip("sankakuがあるかのチェック")] public bool _sankakuCheck;
    [Tooltip("sikakuがあるかのチェック")] public bool _sikakuCheck;
    [SerializeField] Text _checkText;

    [Header("扉")]
    [SerializeField] GameObject _lockDoor;

    public void OnClickmaru()
    {
        if(_maruCheck)
        {
            _checkText.text = "〇の石がはまった";
            LockClearCheck();
        }
        else
        {
            _checkText.text = "はまる石がない";
        }
    }

    public void OnClicksikaku()
    {
        if (_maruCheck)
        {
            _checkText.text = "▢の石がはまった";
            LockClearCheck();
        }
        else
        {
            _checkText.text = "はまる石がない";
        }
    }

    public void OnClicksankaku()
    {
        if (_maruCheck)
        {
            _checkText.text = "△の石がはまった";
            LockClearCheck();
        }
        else
        {
            _checkText.text = "はまる石がない";
        }
    }

    /// <summary>
    /// 全てのStoneを集めてボタンを押したら発動する
    /// </summary>
    void LockClearCheck()
    {
        //ここに扉が開く処理
        if(_maruCheck && _sankakuCheck && _sikakuCheck)
        {

        }
    }
}
