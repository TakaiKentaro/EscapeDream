using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float m_moveSpeed = 1f;
    Rigidbody m_rb = default;

    [SerializeField] GameObject m_staminaGauge;
    RectTransform m_staminaRect;
    [SerializeField] float m_maxValu = 1;
    float m_saveMax;
    bool m_check;
    bool m_stopRun = false;
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_staminaRect = m_staminaGauge.GetComponent<RectTransform>();
        m_saveMax = m_maxValu;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        MoveGuage();
    }
    private void Move()
    {
        if (m_stopRun) m_moveSpeed = 1;
        else m_moveSpeed = 3;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;

        if (dir != Vector3.zero) this.transform.forward = dir;

        if (Input.GetKey("left shift") && !m_stopRun)
        {
            m_moveSpeed = 5;//ダッシュ時スピードアップ

            if (h != 0 || v != 0)
            {
                m_check = true;
            }
        }
        if (Input.GetKeyUp("left shift") && !m_stopRun)
        {
            m_check = false;
            m_moveSpeed = 3;//離すと戻る
        }
        m_rb.velocity = dir.normalized * m_moveSpeed + m_rb.velocity.y * Vector3.up;
    }

    void MoveGuage()
    {
        if (m_check && m_maxValu > 0)
        {
            m_maxValu -= Time.deltaTime;
        }
        else if (m_maxValu < m_saveMax)
        {
            m_maxValu += Time.deltaTime;
        }
        if (m_maxValu <= 0　&& !m_stopRun)
        {
            m_stopRun = true;
            StartCoroutine(StaminaLoss());
        }
        m_staminaRect.localScale = new Vector2(m_maxValu, m_staminaRect.localScale.y);
    }

    IEnumerator StaminaLoss()
    {
        yield return new WaitForSeconds(2f);
        m_check = false;
        while (m_maxValu <= m_saveMax)
        {
            
            m_maxValu += Time.deltaTime;
            yield return null;
        }
        m_stopRun = false;
        m_maxValu = m_saveMax;
    }
}

