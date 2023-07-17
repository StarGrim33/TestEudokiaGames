using System.Collections;
using UnityEngine;

public class GunBullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem _criticalEffect;

    private float _lifeTime = 2f;
    private int _damage = 40;
    private float _criticalChance = 0.2f;
    private int _criticalDamageMultiplier = 2;

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
                enemy.ApplyDamage(_damage * _criticalDamageMultiplier);
                Instantiate(_criticalEffect, transform.position, Quaternion.identity);
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
