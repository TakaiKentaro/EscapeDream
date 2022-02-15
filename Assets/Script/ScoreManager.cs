using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int DeathCount { get; private set; }
    public float TimerCount { get; private set; }

    private void Awake()
    {
        if (Instance is null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        Destroy(this);
    }

    void Update()
    {
        TimerCount += Time.deltaTime;
        Debug.Log(TimerCount);
    }

    public void AddDeathCount()
    {
        DeathCount += 1;
    }

    public void ResetNum()
    {
        DeathCount = 0;
        TimerCount = 0;
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }


}

