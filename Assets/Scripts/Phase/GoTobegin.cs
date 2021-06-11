using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTobegin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
       
        yield return new WaitForSeconds(25);
        GameManager.Instance.LoadLevel("MainScreen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
