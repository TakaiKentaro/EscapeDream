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
    [SerializeField] GameObject _moveLockDoor;
    [SerializeField] GameObject _lockPanel;

    Animator _anim;
    private void Start()
    {
        _anim = GameObject.Find(_moveLockDoor.name).GetComponent<Animator>();
    }
    public void OnClickmaru()
    {
        if(_maruCheck)
        {
            _checkText.text = "〇の石がはまった";
            _buttons[0].GetComponent<Image>().sprite = _sprits[0]; 
            LockClearCheck();
            Invoke(nameof(ResetText), 2);
        }
        else
        {
            _checkText.text = "はまる石がない";
            Invoke(nameof(ResetText), 2);
        }
    }

    public void OnClicksikaku()
    {
        if (_sikakuCheck)
        {
            _checkText.text = "▢の石がはまった";
            _buttons[2].GetComponent<Image>().sprite = _sprits[2];
            LockClearCheck();
            Invoke(nameof(ResetText), 2);
        }
        else
        {
            _checkText.text = "はまる石がない";
            Invoke(nameof(ResetText), 2);
        }
    }

    public void OnClicksankaku()
    {
        if (_sankakuCheck)
        {
            _checkText.text = "△の石がはまった";
            _buttons[1].GetComponent<Image>().sprite = _sprits[1];
            LockClearCheck();
            Invoke(nameof(ResetText), 2);
        }
        else
        {
            _checkText.text = "はまる石がない";
            Invoke(nameof(ResetText), 2);
        }
    }

    /// <summary>
    /// 全てのStoneを集めてボタンを押したら発動する
    /// </summary>
    void LockClearCheck()
    {
        //ここに扉が開く処理
        if (_maruCheck && _sankakuCheck && _sikakuCheck)
        {
            _checkText.text = "扉が開いた";
            //_lockPanel.SetActive(false);
            _anim.SetBool("OpenDoor", true);
        }
    }

    void ResetText()
    {
        _checkText.text = "";
    }
}
