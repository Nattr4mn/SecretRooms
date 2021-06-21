using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [HideInInspector]
    public bool isLeft = true;
    [HideInInspector]
    public bool isWait = false;
    public bool canGo = true;


    [SerializeField]
    private List<Transform> points;
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool waitng = false;
    [SerializeField]
    private float secondsWaiting = 3f;
    private int point;
    private Animator _animation;

    // Start is called before the first frame update
    void Start()
    {
        point = 0;
        transform.position = points[point].position;
        _animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canGo)
        {
            _animation.SetInteger("state", 1);
            Flip();

            transform.position = Vector3.MoveTowards(transform.position, points[point].position, speed * Time.deltaTime);

            if (transform.position == points[point].position)
            {
                point++;
                if (point == points.Count)
                    point = 0;

                if(waitng)
                {
                    isWait = true;
                    canGo = false;
                    StartCoroutine(Waiting());
                }
            }
        }
    }

    private void Flip()
    {
        if (transform.position.x - points[point].position.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            isLeft = false;
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            isLeft = true;
        }
    }

    IEnumerator Waiting()
    {
        _animation.SetInteger("state", 0);
        yield return new WaitForSeconds(secondsWaiting);
        _animation.SetInteger("state", 1);
        isWait = false;
        canGo = true;
    }
}
