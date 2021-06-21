using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionButton : MonoBehaviour
{
    public ParticleSystem particle;
    public AudioSource effect;
    public AudioClip explosion;
    public GameObject destroyObject;
    public Sprite activeSprite;

    private void Start()
    {
        particle.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Weight"))
        {
            GetComponent<SpriteRenderer>().sprite = activeSprite;
            destroyObject.SetActive(false);
            effect.PlayOneShot(explosion);
            particle.Play();
        }
    }
}
