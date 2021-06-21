using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkAttack : MonoBehaviour
{
    [SerializeField]
    private float attackRange = 6f;
    [SerializeField]
    private LayerMask enemyLayer;
    RaycastHit2D enemyLeft, enemyRight;


    void FixedUpdate()
    {
        enemyLeft = Physics2D.Raycast(transform.position, Vector2.left, attackRange, enemyLayer);
        enemyRight = Physics2D.Raycast(transform.position, Vector2.right, attackRange, enemyLayer);

        if (enemyLeft.collider && enemyLeft.collider.CompareTag("Player"))
        {
            Attack();
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (enemyRight.collider && enemyRight.collider.CompareTag("Player"))
        {
            Attack();
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            if(GetComponent<EnemyMove>().isWait)
                GetComponent<Animator>().SetInteger("state", 0);
            else
                GetComponent<Animator>().SetInteger("state", 1);

            GetComponent<EnemyMove>().enabled = true;
        }
    }

    void Attack()
    {
        GetComponent<EnemyMove>().enabled = false;
        GetComponent<Animator>().SetInteger("state", 2);
    }
}
