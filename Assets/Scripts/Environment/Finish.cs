using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject finishScreen;
    public GameObject player;
    public AudioSource music;
    public AudioSource effect;
    public AudioClip portalEffect;
    public AudioClip winEffect;
    public Timer timer;

    private Animator _animation;

    private void Start()
    {
        _animation = GetComponent<Animator>();
        _animation.SetTrigger("idle");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            effect.PlayOneShot(winEffect);
            player.GetComponent<PlayerMove>().enabled = false;
            finishScreen.SetActive(true);
        }
    }

    private void Save()
    {
        PlayerPrefs.SetInt("Fruits", player.GetComponent<PlayerTakeItems>().FruitsCount);
        PlayerPrefs.SetString("LevelTime" + SceneManager.GetActiveScene().buildIndex.ToString(), timer.timerCount.ToString());
        PlayerPrefs.SetString("Level" + SceneManager.GetActiveScene().buildIndex, timer.GetTime());
        if (PlayerPrefs.GetInt("CurrentLevel") <= SceneManager.GetActiveScene().buildIndex + 1)
            PlayerPrefs.SetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetFloat("MusicTime", music.time);
    }

    public void Continue()
    {
        Save();
        Time.timeScale = 1f;
        finishScreen.SetActive(false);
        StartCoroutine(Waiting());
    }

    public void Exit()
    {
        Save();
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    IEnumerator Waiting()
    {
        effect.PlayOneShot(portalEffect);
        player.SetActive(false);
        _animation.ResetTrigger("idle");
        _animation.SetTrigger("continue");
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
