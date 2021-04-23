using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("River");

        foreach (GameObject go in gameObjectArray)
        {
            transform.position = new Vector3(this.transform.position.x, -6.0f, this.transform.position.z);
        }
    }
}
