using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <typeparam name="T"></typeparam>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
                if (instance == null)
                {
                    GameObject go = new GameObject(typeof(T).Name, typeof(T));
                    instance = go.GetComponent<T>();
                }
            }
            return instance;
        }
    }

    public static bool IsValidSingleton()
    {
        return (instance != null);
    }

    public static void Nullify()
    {
        instance = null;
    }

    public static void Destroy()
    {
        Destroy(instance.gameObject);
        instance = null;
    }
}
