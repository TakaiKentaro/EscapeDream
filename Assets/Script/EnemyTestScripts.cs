using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyTestScripts : MonoBehaviour
{
    public Transform[] _points;
    [SerializeField, Tooltip("_pointsを循環する")] int _destPoint = 0;
    private NavMeshAgent _navMeshAgent;

    Vector3 _playerPos;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _light;

    float distance;
    [SerializeField] public float _serchRange = 3f;
    [SerializeField] float _quitRange = 5f;
    [SerializeField] bool _tracking = false;

    [SerializeField] Transform _backPoint;

    float m_serchTime;
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.autoBraking = false;

        GotoNextPoint();

        _player = GameObject.FindObjectOfType<PlayerController>().gameObject;
        _light = GameObject.FindObjectOfType<LightController>().gameObject;

        m_serchTime = 3;
    }

    //指定されたポイントに行く
    void GotoNextPoint()
    {
        if (_points.Length == 0)
            return;

        _navMeshAgent.destination = _points[_destPoint].position;

        _destPoint = (_destPoint + 1) % _points.Length;
    }


    void Update()
    {
        //PlayerとEnemyの距離を測る
        _playerPos = _player.transform.position;
        distance = Vector3.Distance(this.transform.position, _playerPos);


        if (_tracking)
        {
            //追跡の時の処理
            if (distance > _quitRange && m_serchTime > 4)
            {
                _tracking = false;
            }

            //Playerを目標とする
            _navMeshAgent.destination = _playerPos;
        }
        else
        {
            //Playerの追跡をはじめる処理
            if (distance < _serchRange)
            {
                if (_light.GetComponent<LightController>().m_isLight == false || _player.GetComponent<PlayerController>().h != 0)
                {
                    m_serchTime = 0;
                    _tracking = true;
                }
            }
                

            // 次の目標地点を選択します
            if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
        m_serchTime += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                this.transform.position = _backPoint.position;
                break;

        }
    }

    void OnDrawGizmosSelected()
    {
        //trackingRangeの範囲を赤いワイヤーフレームで示す
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _serchRange);

        //quitRangeの範囲を青いワイヤーフレームで示す
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _quitRange);
    }
}