using System.Runtime.Serialization;
using UnityEngine;

/// <summary>
/// 메인 매니저
/// </summary>
public class Main : MonoBehaviour
{
    private static Main instance;
    private static bool initialized;
    public static Main Instance
    {
        get
        {
            if (!initialized)
            {
                initialized = true;

                GameObject obj = GameObject.Find("@Main");
                if (obj == null)
                {
                    obj = new() { name = @"Main" };
                    obj.AddComponent<Main>();
                    DontDestroyOnLoad(obj);
                    instance = obj.GetComponent<Main>();
                }
            }
            return instance;
        }
    }

    private readonly ResourceManager _resource = new();
    private readonly PoolManager _pool = new();
    private readonly ObjectManager _objectManager = new();

    public static ResourceManager Resource => Instance != null ? Instance._resource : null;
    public static PoolManager Pool => Instance != null ? Instance._pool : null;
    public static ObjectManager Object => Instance != null ? Instance._objectManager : null;

    public static void Clear()
    {
        Pool.Clear();
    }
}
