using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PauseButtonManager : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] GameObject _pauseCanvas;
    [SerializeField] GameObject _audioCanvas;
    [SerializeField] GameObject _sencivityCanvas;

    [Header("カメラ")]
    [SerializeField] CinemachineVirtualCamera _camera;
    private void Start()
    {
        PauseManager.Instance.PauseEvent += ShowCanvas;
        PauseManager.Instance.PauseEvent += StopLook;

        SceneManager.sceneLoaded += ChengePlayer;
    }

    void ChengePlayer(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _camera.Follow = player.transform;
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
    void StopLook()
    {
            _camera.gameObject.SetActive(false);

    }
    public void MoveLook()
    {
        _camera.gameObject.SetActive(true);
    }
}
