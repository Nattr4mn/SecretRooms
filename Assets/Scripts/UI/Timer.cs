using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timerCount = 0f;

    void Update()
    {
        timerCount += Time.deltaTime;
        GetComponent<Text>().text = GetTime(); ;
    }

    public string GetTime()
    {
        return ((int)timerCount / 60).ToString() + ":" + ((int)timerCount - ((int)timerCount / 60) * 60).ToString("D2");
    }
}
