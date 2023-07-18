using System;
using System.Collections;
using UnityEngine;

public class GunBullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem _criticalEffect;
    [SerializeField] private int _damage;

    private float _lifeTime = 2f;
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
                Debug.Log(_damage * _criticalDamageMultiplier);
            }
            else
            {
                enemy.ApplyDamage(_damage);
                Debug.Log(_damage);
            }
        }
    }
    public void UpgradeDamage(int value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        _damage += value;
        Debug.Log("Current damage is" +  _damage);
    }

    private IEnumerator LifeTime()
    {
        var newWaitForSeconds = new WaitForSeconds(_lifeTime);
        yield return newWaitForSeconds;
        Destroy(gameObject);
    }

    private bool CalculateCriticalChance()
    {
        return UnityEngine.Random.value < _criticalChance;
    }
}
