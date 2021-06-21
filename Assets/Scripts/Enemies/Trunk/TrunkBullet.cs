using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private Sprite spriteDestroy;
    private bool canFly = true;

    private void Start()
    {
        StartCoroutine(WaitDestroy());
    }

    private void Update()
    {
        if(canFly)
            transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            canFly = false;
            GetComponent<SpriteRenderer>().sprite = spriteDestroy;
            Destroy(gameObject);
        }
    }

    private IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(2f);
        canFly = false;
        GetComponent<SpriteRenderer>().sprite = spriteDestroy;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
