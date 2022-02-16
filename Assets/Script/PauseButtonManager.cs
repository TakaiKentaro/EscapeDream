using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtonManager : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] GameObject _pauseCanvas;
    [SerializeField] GameObject _audioCanvas;
    [SerializeField] GameObject _sencivityCanvas;
    private void Start()
    {
        PauseManager.Instance.PauseEvent += ShowCanvas;
    }

    void ShowCanvas()
    {
        _pauseCanvas.SetActive(true);
    }
    public void OnClickAudio()
    {
        _audioCanvas.SetActive(true);
    }
    public void OnClickSecitivity()
    {
        _sencivityCanvas.SetActive(true);
    }
    public void OnClickBack()
    {
        _pauseCanvas.SetActive(false);
    }
}
