using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Phase : MonoBehaviour
{

    public Image Finish_Game;
    public string scene; 
    public int transitionTime;
    
    void Start()
    {
        Finish_Game.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    	if(collision.tag == "Player") 
    	{
    	   Finish_Game.enabled = true;
    	   StartCoroutine(GotoMainScreen());
    	}
    
    }
      IEnumerator GotoMainScreen()
    {
       yield return new WaitForSeconds(transitionTime);
       GameManager.Instance.LoadLevel(scene);
    }
    
}
