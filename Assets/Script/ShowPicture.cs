using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPicture : MonoBehaviour
{
    [Header("画像を入れておく配列")]
    [SerializeField] GameObject[] _imageObject;

    void Start()
    {
        //はじめに画像を全てfalseにしておく
        ResetImage();
    }

    //引数に入っている番号のImageを呼び出す
    public void ShowImage(int i)
    {
        _imageObject[i].SetActive(true);
    }

    public void ResetImage()
    {
        foreach (var k in _imageObject)
        {
            k.SetActive(false);
        }
    }
}
