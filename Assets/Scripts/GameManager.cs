using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;
using Application = UnityEngine.Application;

public class GameManager : MonoBehaviour
{

    public float timeBeforeStart;
    private float time;
    public bool running;

    private static GameManager _instance;

    public static GameManager instance()
    {
        return _instance;
    }
    
    private void Awake()
    {
        if (_instance == null) _instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        time = timeBeforeStart;
        running = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            running = true;
        }
        time -= Time.deltaTime;
    }
}
