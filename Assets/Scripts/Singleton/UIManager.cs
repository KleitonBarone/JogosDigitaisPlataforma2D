using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button button;
    // Start is called just before any of the Update methods is called the first time
    private void Start()
    {
        //Button button = GameObject.Find("NewGameButton").GetComponent<Button>();
        button.onClick.AddListener(NewGame);
    }



    public void NewGame()
    {
        GameManager.Instance.LoadLevel("Demo");
    }

    public void Quit()
    {
        Application.Quit(0);
    }



}