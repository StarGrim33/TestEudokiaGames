using System;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;
    [SerializeField] private DeadEffectSpawner _deadEffectSpawner;
    [SerializeField] private BuffSpawner _buffSpawner;

    public event UnityAction<EnemyHealth> Dying;

    public int MaxHealth => _maxHealth;

    public int CurrentHealth
    {
        get { return _health; }
        private set
        {
            _health = Mathf.Clamp(value, 0, _maxHealth);

            if (_health <= 0)
                Die();
        }
    }

    private void OnEnable()
    {
        if (_health <= 0)
            _health = _maxHealth;
    }

    public void Die()
    {
        _deadEffectSpawner.SpawnDeadEffect();
        _buffSpawner.SpawnBuff();
        Dying?.Invoke(this);
        gameObject.SetActive(false);
    }

    public void ApplyDamage(int damage)
    {
        if (damage <= 0)
            throw new ArgumentException("Value cannot be negative", nameof(damage));

        CurrentHealth -= damage;
    }
}