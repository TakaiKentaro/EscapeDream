using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{
    [SerializeField] GameObject m_flashLight;
    [SerializeField] GameObject _hand;

    AudioSource _audio;

    public bool m_isLight = true;

       // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _hand = GameObject.Find("HandCollider");
    }

    // Update is called once per frame
    void Update()
    {
        if (_hand.GetComponent<HandScripts>()._moveStop == true) return;
        OnOff();
    }
    
    /// <summary>
    /// ライトのオン・オフの切り替え
    /// </summary>
    void OnOff()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            m_flashLight.SetActive(!m_flashLight.activeSelf);
            if (m_isLight) m_isLight = false;
            else m_isLight = true;
            _audio.Play();
            Debug.Log(m_isLight);
        }
    }
}
