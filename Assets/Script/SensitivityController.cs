using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SensitivityController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _cvc;
    public int _povSensitivity = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CinemachinePOV cvcPOV = _cvc.GetCinemachineComponent<CinemachinePOV>();
        cvcPOV.m_VerticalAxis.m_MaxSpeed = _povSensitivity;
        cvcPOV.m_HorizontalAxis.m_MaxSpeed = _povSensitivity;
    }
}
