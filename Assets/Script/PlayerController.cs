using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("プレイヤーの移動")]
    [SerializeField] float _moveSpeed = 1f;
    Rigidbody _rb = default;

    public float h;
    public float v;

    [Header("スタミナゲージ")]
    [SerializeField] GameObject _staminaGauge;
    RectTransform _staminaRect;

    [SerializeField] float _maxValu = 1;
    float _saveMax;
    bool _check;
    bool _stopRun = false;

    [Header("敵")]
    [SerializeField] GameObject _enemy;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _staminaRect = _staminaGauge.GetComponent<RectTransform>();
        _enemy = GameObject.Find("TestEnemy");
        _saveMax = _maxValu;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        MoveGuage();
    }
    private void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if (_stopRun) _moveSpeed = 1;
        else _moveSpeed = 3;

        
        Vector3 dir = new Vector3(h, 0, v);
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;

        if (dir != Vector3.zero) this.transform.forward = dir;

        if (Input.GetKey("left shift") && !_stopRun)
        {
            _moveSpeed = 5;//ダッシュ時スピードアップ

            if (h != 0 || v != 0)
            {
                _enemy.GetComponent<EnemyTestScripts>()._serchRange = 5;
                _check = true;
            }
        }
        if (Input.GetKeyUp("left shift") && !_stopRun)
        {
            _check = false;
            _moveSpeed = 3;//歩きスピード
        }
        _rb.velocity = dir.normalized * _moveSpeed + _rb.velocity.y * Vector3.up;
    }

    void MoveGuage()
    {
        if (_check && _maxValu > 0)
        {
            _maxValu -= Time.deltaTime;
        }
        else if (_maxValu < _saveMax)
        {
            _maxValu += Time.deltaTime;
        }
        if (_maxValu <= 0　&& !_stopRun)
        {
            _stopRun = true;
            StartCoroutine(StaminaLoss());
        }
        _staminaRect.localScale = new Vector2(_maxValu, _staminaRect.localScale.y);
    }

    IEnumerator StaminaLoss()
    {
        yield return new WaitForSeconds(2f);
        _check = false;
        while (_maxValu <= _saveMax)
        {
            
            _maxValu += Time.deltaTime;
            yield return null;
        }
        _stopRun = false;
        _maxValu = _saveMax;
    }
}

