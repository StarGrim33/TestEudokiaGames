using UnityEngine;

public class DeadEffectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _dieEffects;

    public void SpawnDeadEffect()
    {
        var randomEffect = Random.Range(0, _dieEffects.Length);
        Instantiate(_dieEffects[randomEffect], transform.position, Quaternion.identity);
    }
}
