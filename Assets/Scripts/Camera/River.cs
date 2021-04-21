using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    public GameObject playerCamera;
    public float length, startPos;
    public float parallaxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float river_y = -6.07f;
        float temp = (playerCamera.transform.position.x * (1 - parallaxSpeed));
        float distance = (playerCamera.transform.position.x * parallaxSpeed);

        transform.position = new Vector3(startPos + distance, river_y, transform.position.z);



        if (temp > startPos + length)
        {
            startPos += length;
        }
        else if (temp < startPos - length)
        {
            startPos -= length;
        }
    }
}
