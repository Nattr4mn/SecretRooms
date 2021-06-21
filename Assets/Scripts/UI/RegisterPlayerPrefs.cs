using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class RegisterPlayerPrefs : MonoBehaviour
{
    [SerializeField]
    private Transform defaultCharacter;
    void Start()
    {
        if (!PlayerPrefs.HasKey("Music"))
            PlayerPrefs.SetFloat("Music", 1f);

        if (!PlayerPrefs.HasKey("MusicTime"))
            PlayerPrefs.SetFloat("MusicTime", 0f);

        if (!PlayerPrefs.HasKey("Effects"))
            PlayerPrefs.SetFloat("Effects", 1f);

        if (!PlayerPrefs.HasKey("CurrentLevel"))
            PlayerPrefs.SetInt("CurrentLevel", 1);

        if (!PlayerPrefs.HasKey("Level1"))
            PlayerPrefs.SetString("Level1", "00:00");

        if (!PlayerPrefs.HasKey("Level2"))
            PlayerPrefs.SetString("Level2", "00:00");

        if (!PlayerPrefs.HasKey("Level3"))
            PlayerPrefs.SetString("Level3", "00:00");

        if (!PlayerPrefs.HasKey("Level4"))
            PlayerPrefs.SetString("Level4", "00:00");

        if (!PlayerPrefs.HasKey("Level5"))
            PlayerPrefs.SetString("Level5", "00:00");

        if (!PlayerPrefs.HasKey(defaultCharacter.name))
            PlayerPrefs.SetString(defaultCharacter.name, "selected");

        if (!PlayerPrefs.HasKey("Player"))
            PlayerPrefs.SetString("Player", defaultCharacter.name);

        if (!PlayerPrefs.HasKey("Fruits"))
            PlayerPrefs.SetInt("Fruits", 0);
    }
}
