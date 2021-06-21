using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Records : MonoBehaviour
{
    public Text time;
    public int levelID;

    void Start()
    {
        time.text = PlayerPrefs.GetString("Level" + levelID);
    }
}
