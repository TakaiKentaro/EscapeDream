using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonSystem : MonoBehaviour
{
    public static SingletonSystem Instance = default;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int TimeCount
    {
        get { return TimeCount; }
        set { TimeCount = value; }
    }
    
}
