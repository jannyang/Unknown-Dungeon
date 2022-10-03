using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T _instance;
    public static T instance
    {
        get
        {
            T obj = GameObject.FindObjectOfType<T>();
            if (obj)
                _instance = obj;
            else if (_instance == null)
            {
                GameObject inst = new GameObject();
                inst.name = typeof(T).Name;
                _instance = inst.AddComponent<T>();

                if (_instance is Singleton<T> singleton)
                {
                    singleton.Init();
                }
            }
            return _instance;
        }
    }

    virtual public void Init()
    {

    }
}