using System.Collections;
using UnityEngine;

public class GunBullet : MonoBehaviour
{
    private float _lifeTime = 2f;
    private int _damage = 40;

    private void OnEnable()
    {
        StartCoroutine(LifeTime());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IDamageable>(out IDamageable enemy))
        {
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
}
