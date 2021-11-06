using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] GameObject m_flashLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnOff();
    }
    void OnOff()
    {
        if (Input.GetButtonDown ("Fire1")) m_flashLight.SetActive(!m_flashLight.activeSelf);
    }
}
