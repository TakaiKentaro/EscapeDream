using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] GameObject m_flashLight;

    [SerializeField] GameObject m_lowBattery;
    [SerializeField] GameObject m_mainBattery;
    [SerializeField] GameObject m_subBattery1;
    [SerializeField] GameObject m_subBattery2;
    [SerializeField] GameObject m_subBattery3;
    [SerializeField] GameObject m_subBattery4;

    public float m_batteryCapacity = 100;

    bool m_isLight = true;
       // Start is called before the first frame update
    void Start()
    {
        m_lowBattery.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        OnOff();
    }
    void OnOff()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            m_flashLight.SetActive(!m_flashLight.activeSelf);
            switch(m_isLight)
            {
                case true:
                    m_isLight = false;
                    break;
                case false:
                    m_isLight = true;
                    break;
            }
        }

        if(m_isLight)
        {
            ButteryGuage();
        }
    }
    void ButteryGuage()
    {
        if(m_batteryCapacity > 0) m_batteryCapacity -= Time.deltaTime;

        Debug.Log(m_batteryCapacity);
        if(100 > m_batteryCapacity) m_subBattery1.SetActive(true);
        if (75 > m_batteryCapacity)
        {
            m_subBattery1.SetActive(false);
            m_subBattery2.SetActive(true);
        }
        if (55 > m_batteryCapacity)
        {
            m_subBattery2.SetActive(false);
            m_subBattery3.SetActive(true);
        }
        if (35 > m_batteryCapacity)
        {
            m_subBattery3.SetActive(false);
            m_subBattery4.SetActive(true);
        }
        if (15 > m_batteryCapacity)
        {
            m_subBattery4.SetActive(false);
            m_lowBattery.SetActive(false);
        }
        if (5 >= m_batteryCapacity)
        {
            m_lowBattery.SetActive(true);
            m_flashLight.SetActive(false);
        }
    }
}
