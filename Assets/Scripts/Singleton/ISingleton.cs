using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISingleton<T> : MonoBehaviour where T : ISingleton<T>
{
    private static T _uniqueInstace;
    public static T Instance { get { return _uniqueInstace; } }

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        if (_uniqueInstace != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _uniqueInstace = (T)this;
        }
    }

    // This function is called when the MonoBehaviour will be destroyed
    private void OnDestroy()
    {
        _uniqueInstace = null;
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