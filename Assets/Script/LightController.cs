using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{
    [SerializeField] GameObject m_flashLight;

    public bool m_isLight = true;

       // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
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
        }
    }

    /// <summary>
    /// バッテリーゲージのImage
    /// </summary>
    void ButteryGuage()
    {
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Item")) _itemText.SetActive(true);
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Item")) _itemText.SetActive(false);
    //}
}
