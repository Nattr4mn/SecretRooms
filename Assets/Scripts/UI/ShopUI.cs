using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField]
    private Text quantityFruits;
    void Update()
    {
        quantityFruits.text = PlayerPrefs.GetInt("Fruits").ToString();
    }
}
