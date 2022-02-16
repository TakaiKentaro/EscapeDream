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
        _saveTime = CountManager.GetTime();
        _saveDeathCount = CountManager.GetCount();

        int minutes = Mathf.FloorToInt(_saveTime / 60F);
        int seconds = Mathf.FloorToInt(_saveTime - minutes * 60);

        _timerText.text = "クリアタイム　"　+ minutes + "分"　+ seconds + "秒";
        _deathCountText.text = "死亡回数　"+_saveDeathCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
