using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject m_Player;
    [SerializeField] SphereCollider searchArea;
    [SerializeField] float searchAngle = 130f;
    private NavMeshAgent navMeshAgent;

    public GameObject m_Light;
    bool m_isSerch;
    float m_serchTime;

    // Start is called before the first frame update
    void Start()
    {
        m_Light = GameObject.Find("Flashlight");
        m_Player = GameObject.Find("Player");

        // NavMeshAgentを保持しておく
        navMeshAgent = GetComponent<NavMeshAgent>();
        m_serchTime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーを目指して進む
        //navMeshAgent.destination = player.transform.position;
        if(m_isSerch || m_serchTime < 3)
        {
            Serch();
        }
        m_serchTime += Time.deltaTime;
    }

    void Serch()
    {
        if (m_Light.GetComponent<LightController>().m_isLight == false || m_Player.GetComponent<PlayerController>().h != 0)
        {
            navMeshAgent.destination = m_Player.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_isSerch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_isSerch = false;
            m_serchTime = 0;
        }
    }
}