using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //=============================================================
    //Zaczyna odliczanie po stowrzeniu obiektu spawner, wyœwietla 
    //czas na UI
    //=============================================================
    //Reference to parent
    Parent parent;

    private float start_time;
    public static bool finished;
    
    void Start()
    {
        parent = FindObjectOfType<Parent>();
        start_time = Time.time;
        finished = false;
    }


    void Update()
    {
        if (finished)
            return;
        float t = Time.time - start_time;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        if(t % 60 < 10)
            parent.timer_text.text = "Timer: 0" + minutes + ",0" + seconds;
        else
            parent.timer_text.text = "Timer: 0" + minutes + "," + seconds;
    }

}
