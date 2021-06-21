using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public void StartDeath()
    {
        StartCoroutine(Death());
    }

    private IEnumerator Death()
    {
        GetComponent<Animator>().SetInteger("state", 3);

        if (GetComponent<EnemyDamage>())
            GetComponent<EnemyDamage>().isDeath = true;
        if (GetComponent<EnemyMove>())
            GetComponent<EnemyMove>().canGo = false;

        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 400, ForceMode2D.Force);
        transform.GetChild(0).GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
