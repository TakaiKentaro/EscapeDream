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
        _fadeImage.gameObject.SetActive(true);
        DoFadeImageOut(0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(_check)
        {
            DoFadeImageIn(1f);
            _check = false;
        }
    }

    public void DoFadeImageOut(float color)
    {
        _fadeImage.DOFade(color, 3f);
    }

    public void DoFadeImageIn(float color)
    {
        _fadeImage.DOFade(color, 3f).OnComplete(() => SceneManager.LoadScene("MAP"));
    }

}
