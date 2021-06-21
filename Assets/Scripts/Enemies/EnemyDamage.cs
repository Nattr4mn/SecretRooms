using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public bool isDeath = false;
    [SerializeField]
    private int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && !isDeath)
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(-damage);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 700, ForceMode2D.Force);
        }
    }
}
