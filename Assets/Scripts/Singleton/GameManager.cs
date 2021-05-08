using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : IPersistentSingleton<GameManager>
{

    public void LoadLevel(string levelName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
        if (asyncOperation == null)
        {
            Debug.LogError("Deu Pau");
            return;
        }
        asyncOperation.completed += OnLoadOperationComplete;
    }

    private void OnLoadOperationComplete(AsyncOperation asyncOperation)
    {

    }


}