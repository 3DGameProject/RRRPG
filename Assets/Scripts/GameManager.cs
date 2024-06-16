using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    private static object lockObject = new object();
    private static bool applicationIsQuitting = false;

    public static T Instance
    {
        get
        {
            if(applicationIsQuitting)
            {
                return null;
            }

            lock(lockObject)
            {
                if(instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));

                    if(FindObjectsOfType(typeof(T)).Length > 1 ) 
                    { 
                        return instance;
                    }
                }

                if(instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<T>();
                    singletonObject.name = typeof(T).ToString() + " (Singleton)";

                    DontDestroyOnLoad(singletonObject);
                }
            }
            return instance;
        }
    }
    private void OnDestroy()
    {
        applicationIsQuitting =true;
    }
}

public class GameManager : Singleton<GameManager>
{
    public MapGenerator mapGenerator;

    void Start()
    {
        
    }

    void Update()
    {
        mapGenerator.GetMapFromSPool();
    }
}
