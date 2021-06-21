using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private Slider music, effects;
    void Start()
    {
        music.value = PlayerPrefs.GetFloat("Music");
        effects.value = PlayerPrefs.GetFloat("Effects");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("Music", music.value);
        PlayerPrefs.SetFloat("Effects", effects.value);
    }
}
