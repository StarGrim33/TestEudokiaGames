using UnityEngine;

public class EnemyKiller : MonoBehaviour
{
    [SerializeField] private GameObject _enemyContainer;

    public void KillEnemies()
    {
        for (int i = 0; i < _enemyContainer.transform.childCount; i++)
        {
            if (_enemyContainer.transform.GetChild(i).TryGetComponent<Enemy>(out Enemy enemy))
            {
                if (enemy.gameObject.activeInHierarchy)
                {
                    enemy.gameObject.SetActive(false);
                }
            }
        }
    }
}
