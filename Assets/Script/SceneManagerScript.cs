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

    // Start is called before the first frame update
    void Start()
    {
        _fadeImage.gameObject.SetActive(true);
        DoFadeImageOut(0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_check)
        {
            DoFadeImageIn(1f);
            _check = false;
        }
        if (_enterCheck)
        {
            DoEnterFade(1f);
            _enterCheck = false;
        }
        if (_startCheck)//スタートシーンでドアから移動したときに呼ぶ
        {
            DoFadeHousePoint(1f);
            _startCheck = false;
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

    public void DoFadeImageIn(float color)
    {
        _fadeImage.DOFade(color, 3f).OnComplete(() => SceneManager.LoadScene("SampleScene"));
    }

    public void DoEnterFade(float color)
    {
        _fadeImage.DOFade(color, 3f).OnComplete(() => SceneManager.LoadScene("SampleScene"));
    }

}
