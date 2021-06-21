using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    public Transform[] points;
    public bool canMove = true;
    public float waitingTime;
    public float speed;
    
    private Animator animator;
    private int pointIndex = 1;

    public void Move(ref Animator anim)
    {
        animator = anim;

        if (canMove)
        {
            animator.SetInteger("state", 0);
            Flip();
            transform.position = Vector3.MoveTowards(transform.position, points[pointIndex].position, speed * Time.deltaTime);

            if (transform.position == points[pointIndex].position)
            {
                canMove = false;
                pointIndex++;
                if (pointIndex >= points.Length)
                    pointIndex = 0;

                StartCoroutine(Waiting());
            }
        }
    }

    private void Flip()
    {
        if ((points[pointIndex].position.x - transform.position.x) > 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        else
            transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    public void TP()
    {
        transform.position = points[pointIndex].position;
    }

    private IEnumerator Waiting()
    {
        yield return new WaitForSeconds(waitingTime);
        StartCoroutine(Teleportation());
    }

    private IEnumerator Teleportation()
    {
        animator.SetInteger("state", 1);
        yield return new WaitForSeconds(0.2f);

        animator.SetInteger("state", 2);
        yield return new WaitForSeconds(0.2f);

        animator.SetInteger("state", 0);
        yield return new WaitForSeconds(waitingTime);

        pointIndex++;
        canMove = true;
    }
}
