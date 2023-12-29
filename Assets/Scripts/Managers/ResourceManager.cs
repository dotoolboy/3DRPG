using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceManager
{
    private Dictionary<string, GameObject> models = new();

    /// <summary>
    /// Resources ���� �� ������ �ҷ�����
    /// </summary>
    public void Initialize()
    {
        LoadPrefabs("Prefabs", models);
    }

    #region Prefab

    /// <summary>
    /// ������ ��� �ȿ� ��� �����յ� �ε�
    /// </summary>
    /// <param name="path">���� ���</param>
    /// <param name="prefabs">�ε��� ������ ��</param>
    private void LoadPrefabs(string path, Dictionary<string, GameObject> prefabs)
    {
        GameObject[] objs = Resources.LoadAll<GameObject>(path);
        foreach (GameObject obj in objs)
        {
            prefabs[obj.name] = obj;
        }
    }

    /// <summary>
    /// string key�� ������� ������Ʈ ��������
    /// </summary>
    /// <param name="prefabName"></param>
    /// <returns></returns>
    public GameObject GetObject(string prefabName)
    {
        if (!models.TryGetValue(prefabName, out GameObject prefab)) return null;
        return prefab;
    }

    #endregion

    #region Pool

    public GameObject InstantiatePrefab(string key, Transform parent = null, bool pooling = false)
    {
        GameObject prefab = GetObject(key);
        if (prefab == null)
        {
            return null;
        }

        if (pooling) return Main.Pool.Pop(prefab);

        GameObject obj = UnityEngine.Object.Instantiate(prefab, parent);
        obj.name = prefab.name;
        return obj;
    }

    // �ش� ������Ʈ�� Ǯ�� �������ų� �ı��Ѵ�.
    public void Destroy(GameObject obj)
    {
        if (obj == null) return;

        if (Main.Pool.Push(obj)) return;

        Object.Destroy(obj);
    }

    #endregion
}
