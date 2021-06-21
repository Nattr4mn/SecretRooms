using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitCount : MonoBehaviour
{
    [SerializeField]
    private Text count;
    [SerializeField]
    private PlayerTakeItems playerItems;


    private void Update()
    {
        count.text = playerItems.FruitsCount.ToString();
    }
}
