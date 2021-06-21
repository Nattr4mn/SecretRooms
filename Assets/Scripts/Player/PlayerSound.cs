using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip jump, fruit, hit;

    private void Start()
    {
        audioSource.volume = PlayerPrefs.GetFloat("Effects");
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jump);
    }

    public void PlayFruitTakeSound()
    {
        audioSource.PlayOneShot(fruit);
    }

    public void PlayHitSound()
    {
        audioSource.PlayOneShot(hit);
    }
}
