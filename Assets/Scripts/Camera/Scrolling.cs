using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    private float length, startposX, startposY;
    [SerializeField]
    private float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startposX = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distX = Camera.main.transform.position.x * parallaxEffect;
        float distY = Camera.main.transform.position.y * parallaxEffect;
        transform.position = new Vector3(startposX + distX, startposY + distY, transform.position.z);
    }
}
