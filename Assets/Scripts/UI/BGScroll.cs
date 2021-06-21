using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    [SerializeField]
    private float parallax;
    private float posX, posY;
    private void Start()
    {
        posX = transform.position.x;
        posY = transform.position.y;
    }
    void Update()
    {
        float newPosX = posX + (Camera.main.ScreenToWorldPoint(Input.mousePosition).x * parallax);
        float newPosY = posY + (Camera.main.ScreenToWorldPoint(Input.mousePosition).y * parallax);

        transform.position = new Vector3(newPosX, newPosY, transform.position.z);
    }
}
