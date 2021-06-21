using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public AudioSource effect;
    public AudioClip hit;

    [SerializeField]
    private int quantityDropFruits;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            effect.PlayOneShot(hit);
            collision.gameObject.GetComponent<PlayerTakeItems>().RecountFruits(quantityDropFruits);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 800);
            transform.parent.GetComponent<EnemyDeath>().StartDeath();
        }
    }
}
