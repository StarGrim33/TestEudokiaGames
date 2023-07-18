using Unity.VisualScripting;
using UnityEngine;

public class PowerUP : MonoBehaviour
{
    [SerializeField] private Buffs _buffs;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            _buffs.ApplyPowerUP(player.gameObject);
            Destroy(gameObject);
        }
    }
}
