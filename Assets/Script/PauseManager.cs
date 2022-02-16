using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseManager : MonoBehaviour
{
    public delegate void Pause();
    public Pause PauseEvent;

    public Pause PauseEnd;
    public static PauseManager Instance { get; private set; }

    public static bool IsAlive() => Instance != null;

    private void Awake()
    {
        if (!IsAlive()) 
        {
            Instance = this;
            DontDestroyOnLoad(this);
            return;
        }
        Destroy(this);
    }
    public void PauseEv()
    {
        PauseEvent?.Invoke();
    }

    public void PauseEndEv()
    {
        PauseEnd?.Invoke();
    }
    
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        { 
            PauseEv(); 
        }
    }

    private void OnDestroy()
    {
        if(Instance == this)
        {
            Instance = null;
        }
    }
}
