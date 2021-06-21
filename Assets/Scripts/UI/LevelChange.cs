using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    [SerializeField]
    private GameObject levelList;
    void Start()
    {
        for(int i = 0; i < PlayerPrefs.GetInt("CurrentLevel"); i++)
            levelList.transform.GetChild(i).GetComponent<Button>().interactable = true;
    }

    public void Load(int lvlIndex)
    {
        SceneManager.LoadScene(lvlIndex);
    }
}
