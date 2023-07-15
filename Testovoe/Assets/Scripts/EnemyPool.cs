using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool EnemyPoolInstance;

    [SerializeField] private int _zombieCount;
    [SerializeField] private GameObject _zombiePrefab;
    [SerializeField] private List<GameObject> _zombieList;
    [SerializeField] private GameObject _container;

    private void Awake()
    {
        EnemyPoolInstance = this;
        CreateObjects(_zombiePrefab, _container.transform, _zombieCount, _zombieList);
    }

    private void CreateObjects(GameObject prefab, Transform parent, int count, List<GameObject> list)
    {
        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate(prefab, parent);
            obj.gameObject.SetActive(false);
            list.Add(obj);
        }
    }

    public GameObject GetObject(GameObject prefab)
    {
        List<GameObject> list = new List<GameObject>();

        if (prefab == _zombiePrefab)
            list = _zombieList;

        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].activeInHierarchy)
                return list[i];
        }

        return null;
    }
}
