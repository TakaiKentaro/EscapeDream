using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScene : MonoBehaviour
{
    [Header("テキスト")]
    [SerializeField] Text _timerText;
    [SerializeField] Text _deathCountText;

    float _saveTime;
    int _saveDeathCount;
    // Start is called before the first frame update
    void Start()
    {
        _saveTime = ScoreManager.Instance.TimerCount;
        _saveDeathCount = ScoreManager.Instance.DeathCount;
        
        _timerText.text = _saveTime.ToString();
        _deathCountText.text = _saveDeathCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
