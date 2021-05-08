using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPersistentSingleton<T> : MonoBehaviour where T : IPersistentSingleton<T>
{
    private static T _uniqueInstance;

    public static T Instance
    {
        get
        {
            if (_uniqueInstance == null)
            {
                return new GameObject("Game Manager").AddComponent<T>();
            }
            else
            {
                return _uniqueInstance;
            }
        }
        set
        {
            if (_uniqueInstance == null)
            {
                _uniqueInstance = value;
                DontDestroyOnLoad(value.gameObject);
            }
            else if (_uniqueInstance != value)
            {
                Destroy(value.gameObject);
            }
        }
    }


    // Awake is called when the script instance is being loaded
    protected virtual void Awake()
    {
        Instance = this as T;
    }

    // This function is called when the MonoBehaviour will be destroyed
    protected virtual void OnDestroy()
    {
        if (_uniqueInstance != null && _uniqueInstance == this)
            _uniqueInstance = null;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}