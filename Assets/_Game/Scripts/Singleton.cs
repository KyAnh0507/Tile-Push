using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                //find singleton
                instance = FindObjectOfType<T>();

                //create new in instance if one doesn't already exist

                if(instance == null)
                {
                    // Need to create a new GameObject to attach the singleton to.

                    var singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<T>();
                    singletonObject.name = typeof(T).ToString() + " (Singleton)";
                }
               
            }
            return instance;
        }
    }

    public virtual void Awake()
    {
        instance = GetComponent<T>();
    }
}
