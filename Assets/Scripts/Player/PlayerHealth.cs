using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public PlayerSound playerSound;
    public int HP => healthPoint;
    public int MaxHP => maxHealthPoint;


    [SerializeField]
    private int maxHealthPoint;
    [SerializeField]
    private int healthPoint;
    private Animator _animation;
    private bool canHit = true;



    private void Start()
    {
        healthPoint = maxHealthPoint;
        _animation = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if(canHit)
        {
            if (damage < 0)
            {
                playerSound.PlayHitSound();
                canHit = false;
                StartCoroutine(Hit());
                healthPoint += damage;
            }
            else
            {
                if (healthPoint < maxHealthPoint)
                {
                    if (healthPoint + damage >= maxHealthPoint)
                        healthPoint = maxHealthPoint;
                    else
                        healthPoint += damage;
                }
            }

            if (healthPoint <= 0)
            {
                healthPoint = 0;
                Death();
            }
        }
    }

    private IEnumerator Hit()
    {
        GetComponent<PlayerMove>().canGo = false;
        _animation.SetInteger("state", 4);
        yield return new WaitForSeconds(0.5f);
        canHit = true;
        GetComponent<PlayerMove>().canGo = true;
    }

    private void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
