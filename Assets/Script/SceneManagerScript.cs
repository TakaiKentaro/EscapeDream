using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] Image _fadeImage;
    public bool _check = false;

    // Start is called before the first frame update
    void Start()
    {
        //_fadeImage.DOFade(255f, 3f).OnComplete(() => SceneManager.LoadScene("MAP"));
        //float alfa = _fadeImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if(_check)
        {
            DoFadeImage(1f);
            _check = false;
        }
    }

    void DoFadeImage(float color)
    {
        _fadeImage.DOFade(color, 3f).OnComplete(() => SceneManager.LoadScene("MAP"));
        _check = false;
    }
}
