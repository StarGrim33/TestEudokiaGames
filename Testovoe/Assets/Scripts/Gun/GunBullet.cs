using System.Collections;
using UnityEngine;

public class GunBullet : MonoBehaviour
{
    private float _lifeTime = 1f;

    private void OnEnable()
    {
        StartCoroutine(LifeTime());
    }

    private IEnumerator LifeTime()
    {
        var newWaitForSeconds = new WaitForSeconds(_lifeTime);
        yield return newWaitForSeconds;
        Destroy(gameObject);
    }
}
