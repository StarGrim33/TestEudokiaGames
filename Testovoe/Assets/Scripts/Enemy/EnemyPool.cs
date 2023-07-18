using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool EnemyPoolInstance;

    [SerializeField] private int _slimeCount;
    [SerializeField] private GameObject _slimePrefab;
    [SerializeField] private List<GameObject> _slimeList;

    [SerializeField] private int _tirtleCount;
    [SerializeField] private GameObject _tirtlePrefab;
    [SerializeField] private List<GameObject> _tirtleList;

    [SerializeField] private GameObject _container;

    private void Awake()
    {
        EnemyPoolInstance = this;
        CreateObjects(_slimePrefab, _container.transform, _slimeCount, _slimeList);
        CreateObjects(_tirtlePrefab, _container.transform, _tirtleCount, _tirtleList);
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

        if (prefab == _slimePrefab)
            list = _slimeList;

        if (prefab == _tirtlePrefab)
            list = _tirtleList;

        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].activeInHierarchy)
                return list[i];
        }

        return null;
    }
}
