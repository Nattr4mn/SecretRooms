using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsVolume : MonoBehaviour
{
    public AudioSource music;
    public AudioSource effects;
    public bool isMenu = false;

    private void Start()
    {
        if(!isMenu)
        {
            if (!PlayerPrefs.HasKey("MusicName"))
                PlayerPrefs.SetString("MusicName", music.name);

            if (music.clip.length <= PlayerPrefs.GetFloat("MusicTime") || PlayerPrefs.GetString("MusicName") != music.name)
            {
                PlayerPrefs.SetString("MusicName", music.name);
                PlayerPrefs.SetFloat("MusicTime", 0f);
            }

            music.time = PlayerPrefs.GetFloat("MusicTime");
        }
        else
            PlayerPrefs.SetFloat("MusicTime", 0f);

    }

    void Update()
    {
        if (music.clip.length <= PlayerPrefs.GetFloat("MusicTime"))
            PlayerPrefs.SetFloat("MusicTime", 0f);

        PlayerPrefs.SetFloat("MusicTime", music.time);

        music.volume = PlayerPrefs.GetFloat("Music");
        effects.volume = PlayerPrefs.GetFloat("Effects");
    }
}
