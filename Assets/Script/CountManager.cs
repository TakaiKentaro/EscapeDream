using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountManager : MonoBehaviour
{
    public static float _timeCount = 0;
    public static int _deathCount = 0;

    float AddTime;
    int AddDeath;
    // Start is called before the first frame update

    private void Update()
    {
        AddTime += Time.deltaTime;
        _timeCount = AddTime;
        //Debug.Log(_timeCount);
    }

    public void AddCount()
    {
        AddDeath++;
        _deathCount = AddDeath;
    }

    public void RestNum()
    {
        AddTime = 0;
        AddDeath = 0;
    }
    public static float GetTime()
    {
        return _timeCount;
    }
    public static int GetCount()
    {
        return _deathCount;
    }
}
