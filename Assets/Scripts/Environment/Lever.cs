using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject portal;
    public Sprite activeSprite;
    public AudioSource effect;
    public AudioClip leverEffect;
    private bool isActive = false;
    private bool playerEnter = false;
    private bool activate = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isActive)
        {
            playerEnter = true;
            if (Input.GetButton("Use") || activate)
            {
                isActive = true;
                GetComponent<SpriteRenderer>().sprite = activeSprite;
                effect.PlayOneShot(leverEffect);
                portal.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) { playerEnter = false; }

    public void Activate()
    {
        if(playerEnter)
            activate = true;
    }
}
