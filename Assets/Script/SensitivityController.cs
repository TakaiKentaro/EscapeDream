using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SensitivityController : MonoBehaviour
{
    GameObject _cvc;
    public int _povSensitivity = 0;

    [SerializeField] Canvas _canvas;

    CinemachinePOV _pov;

    void Start()
    {
        _cvc = FindObjectOfType<CinemachineVirtualCameraBase>().gameObject;
        _pov = _cvc.GetComponent<CinemachinePOV>();
    }

    public void DisplayCanvas()
    {
        _canvas.gameObject.SetActive(true);
    }
    public void CloseCanvas()
    {
        _canvas.gameObject.SetActive(false);
    }

    public void SensivilitySet(int power)
    {
        _povSensitivity = power;

        //CinemachinePOV cvcPOV = _cvc.GetCinemachineComponent<CinemachinePOV>();

        _pov.m_VerticalAxis.m_MaxSpeed = _povSensitivity;
        _pov.m_HorizontalAxis.m_MaxSpeed = _povSensitivity;
    }
}
