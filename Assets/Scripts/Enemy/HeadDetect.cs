using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDetect : MonoBehaviour
{
    GameObject Enemi;

    // Update is called once per frame
    void Update()
    {
        Enemi = gameObject.transform.parent.gameObject;
        if(Enemi.transform.position.y < -3.8f) {Destroy(Enemi);}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Collider2D>().enabled = false;
            Enemi.GetComponent<SpriteRenderer>().flipY = true;
            Enemi.GetComponent<Collider2D>().enabled = false;
            Vector3 movement = new Vector3(Random.Range(40,70),Random.Range(-40,40),0f);
            Enemi.transform.position = Enemi.transform.position + movement * Time.deltaTime;
            Transform parent = transform.parent;
            GameObject EnemiChild = parent.GetChild(1).gameObject;
            EnemiChild.tag = "Untagged";
        }    
    }
}
