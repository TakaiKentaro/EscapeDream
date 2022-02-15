using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvasManager : MonoBehaviour
{
    [SerializeField] Canvas _canvas;

    public void DisplayCanvas()
    {
        _canvas.gameObject.SetActive(true);
    }
    public void CloseCanvas()
    {
        _canvas.gameObject.SetActive(false);
    }
}
