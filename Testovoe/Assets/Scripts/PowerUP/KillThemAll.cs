using UnityEngine;

public class KillThemAll : MonoBehaviour
{
    [SerializeField] private EnemyKiller _enemyKiller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            _enemyKiller.KillEnemies();
            Destroy(gameObject);
        }
    }
}
