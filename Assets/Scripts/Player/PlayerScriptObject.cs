using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Jogo/Player")]
public class PlayerScriptObject : ScriptableObject
{
    public string savePoint;

    private void Awake()
    {
        savePoint = "SavePoint";
    }


    public Vector2 getCheckpointPosition()
    {
        return GameObject.Find(savePoint).transform.position;
    }


    public void setCheckpointPosition(string SavePointName)
    {
        savePoint = SavePointName;
    }


    public void resetCheckpointPosition()
    {
        savePoint = "SavePoint";
    }
}
