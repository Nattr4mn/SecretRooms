using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeItems : MonoBehaviour
{
    public PlayerSound playerSound;
    public int FruitsCount => fruitsCount;

    private int fruitsCount;

    public void RecountFruits(int fruits)
    {
        fruitsCount += fruits;
    }


    void Start()
    {
        fruitsCount = PlayerPrefs.GetInt("Fruits");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fruit")
        {
            playerSound.PlayFruitTakeSound();
            fruitsCount++;
            Destroy(collision.gameObject);
        }
    }
}
