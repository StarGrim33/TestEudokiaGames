using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private int _amount;

    public float SpawnDelay => _spawnDelay;

    public GameObject EnemyPrefab => _enemyPrefab;

    public int Amount => _amount;
}
