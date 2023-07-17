using System.Collections;
using UnityEngine;

public class GunBullet : MonoBehaviour
{
    private float _lifeTime = 2f;
    private int _damage = 40;
    private int _criticalChance = 20;

    private void OnEnable()
    {
        StartCoroutine(LifeTime());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<IDamageable>(out IDamageable enemy))
        {
            if (CalculateCriticalChance())
            {
                enemy.ApplyDamage(_damage * 2);
                Debug.Log(_damage);
            }

            enemy.ApplyDamage(_damage);
            Debug.Log(_damage);
        }
    }

    private IEnumerator LifeTime()
    {
        var newWaitForSeconds = new WaitForSeconds(_lifeTime);
        yield return newWaitForSeconds;
        Destroy(gameObject);
    }

    private bool CalculateCriticalChance()
    {
        return Random.value < _criticalChance;
    }
}
