using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class SceneManagerScript : MonoBehaviour
{
    [Header("プレイヤーオブジェクト")]
    [SerializeField] GameObject _playerObj;

    [Header("FadeImage")]
    [SerializeField] Image _fadeImage;

    [Header("テレポート用Transform")]
    [SerializeField] Transform _startPoint;

    [Header("シーン転移のbool")]
    public bool _check = false;
    public bool _enterCheck = false;
    public bool _startCheck = false;
    public bool _goDream = false;

    // Start is called before the first frame update
    void Start()
    {
        _fadeImage.color = new Color(0, 0, 0);
        _fadeImage.gameObject.SetActive(true);
        DoFadeImageOut(0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_check)
        {
            DoGoMainGame();
            _check = false;
        }
        if (_enterCheck)
        {
            DoGoal(1f);
            _enterCheck = false;
        }
        if (_startCheck)//スタートシーンでドアから移動したときに呼ぶ
        {
            DoFadeHousePoint(1f);
            _startCheck = false;
        }
        if(_goDream)
        {
            DoGoDrean(1f);
            _goDream = false;
        }
    }
    public void DoFadeImageOut(float color)
    {
        _fadeImage.DOFade(color, 3f);
    }

    public void DoFadeHousePoint(float color)
    {

        _fadeImage.DOFade(color, 3f)
            .OnComplete(() =>
            {
                _playerObj.transform.position = _startPoint.position;
                _fadeImage.DOFade(0f, 3f);
            });
    }

    public void DoGoDrean(float color)//Bedに入った時の関数
    {
        _fadeImage.DOFade(color, 3f).OnComplete(() => SceneManager.LoadScene("DreamScene"));
    }

    public void DoGoMainGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void DoGoal(float color)
    {
        _fadeImage.color = new Color(255, 255, 255);
        _fadeImage.DOFade(color, 3f).OnComplete(() => SceneManager.LoadScene("TitleScene"));
    }

}
