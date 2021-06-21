using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth playerHealth;
    [SerializeField]
    private Image heartImage;
    private int curHP;


    void Start()
    {
        curHP = playerHealth.MaxHP - 1;
        float offset = 0;
        for(int i = 0; i < playerHealth.MaxHP; i++)
        {
            Instantiate(heartImage, new Vector3(transform.position.x + offset, transform.position.y, transform.position.z), Quaternion.identity, transform);
            offset += heartImage.rectTransform.rect.width + 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (curHP > playerHealth.HP - 1)
        {
            while(curHP != playerHealth.HP - 1)
            {
                transform.GetChild(curHP).gameObject.SetActive(false);
                curHP--;
            }
        }

        if (curHP < playerHealth.HP - 1)
        {
            while (curHP != playerHealth.HP - 1)
            {
                curHP++;
                transform.GetChild(curHP).gameObject.SetActive(false);
            }
        }
    }
}
