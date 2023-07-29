using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class PowerUP : MonoBehaviour
{
    [SerializeField] private Buffs _buffs;
    [SerializeField] private Spawner _spawner;

    [Inject]
    public void Construct(Spawner spawner)
    {
        _spawner = spawner;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            _buffs.ApplyPowerUP(player.gameObject);
            Destroy(gameObject);
        }
    }
}
