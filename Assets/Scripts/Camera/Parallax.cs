using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
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

        float temp = (playerCamera.transform.position.x * (1 - parallaxSpeed));
        float distance = (playerCamera.transform.position.x * parallaxSpeed);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
        
        

        if (temp > startPos + length / 2)
        {
            startPos += length;
        }
        else if (temp < startPos - length / 2)
        {
            startPos -= length;
        }
    }
}
