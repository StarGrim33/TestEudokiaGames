using UnityEngine;
using Zenject;

public class BuffSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _buffs;
    [Inject] private DiContainer _containerPrefab;

    public void CalculateSpawnBuffProbability()
    {
        int minNumber = 0;
        int maxNumber = 100;
        int chance = 50;

        if (Random.Range(minNumber, maxNumber) <= chance)
            SpawnBuff();
    }

    public void SpawnBuff()
    {
        var randomBuff = Random.Range(0, _buffs.Length - 1);
        var obj = _containerPrefab.InstantiatePrefab(_buffs[randomBuff], transform.position, Quaternion.identity, null);
        //Instantiate(_buffs[randomBuff], transform.position, Quaternion.identity);
    }
}
