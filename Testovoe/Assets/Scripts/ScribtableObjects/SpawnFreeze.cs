using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "PowerUps/SpawnFreeze", order = 0)]
public class SpawnFreeze : Buffs
{
    [SerializeField] private float _duration;

    public override void ApplyPowerUP(GameObject target)
    {
        Spawner.Instance.FreezeSpawn(_duration);
        Debug.Log("Gathered");
    }
}
