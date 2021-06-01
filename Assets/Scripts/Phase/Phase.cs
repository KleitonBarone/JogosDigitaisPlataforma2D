using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Phase : MonoBehaviour
{

    public Image Finish_Game;
    
    void Start()
    {
   	Finish_Game.gameObject.SetActive(false);
        Finish_Game.enabled = false;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    	if(collision.tag == "Player") 
    	{
    	   Finish_Game.enabled = true;	
    	   Finish_Game.gameObject.SetActive(true);
    	   StartCoroutine(ExampleCoroutine());
    	}
    
    }
    
    
      IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        
            	   GameManager.Instance.LoadLevel("MainScreen");
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}
