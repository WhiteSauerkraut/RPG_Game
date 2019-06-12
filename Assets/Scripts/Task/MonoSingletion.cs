using UnityEngine;
using System.Collections;

/// <summary>
/// 单例管理类
/// </summary>
/// <typeparam name="T"></typeparam>

public abstract class MonoSingletion<T> : MonoBehaviour where T : MonoBehaviour
{

    private static string rootName = "GM";
    private static GameObject monoSingletionRoot;

    private static T instance;
    public static T Instance
    {
        get
        {
            if (monoSingletionRoot == null)
            {
                monoSingletionRoot = GameObject.Find(rootName);
                if (monoSingletionRoot == null)
                    Debug.Log("please create a gameobject named " + rootName);
            }
            if (instance == null)
            {
                instance = monoSingletionRoot.GetComponent<T>();
                if (instance == null)
                    instance = monoSingletionRoot.AddComponent<T>();
            }
            return instance;
        }
    }

}