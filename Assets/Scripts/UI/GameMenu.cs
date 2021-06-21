using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject[] obj;

    private void ObjActive(bool state)
    {
        foreach (var value in obj)
            value.SetActive(state);
    }

    public void Menu()
    {
        Time.timeScale = 0f;
        ObjActive(false);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        ObjActive(true);
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
