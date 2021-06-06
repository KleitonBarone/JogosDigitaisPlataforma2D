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
    	   StartCoroutine(GotoMainScreen());
    	}
    
    }
    
    
      IEnumerator GotoMainScreen()
    {
       yield return new WaitForSeconds(2);
       GameManager.Instance.LoadLevel("MainScreen");
    }
    
}
