using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance = null;
    public static T Instance
    {
        get
        {
            instance ??= FindObjectOfType(typeof(T)) as T;

            if (instance == null)
            {
                GameObject temp = new GameObject(typeof(T).Name);
                instance = temp.AddComponent<T>();
            }

            return instance;
        }
    }
}
