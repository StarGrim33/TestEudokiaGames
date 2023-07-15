using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunBullet _bulletPrefab;
    [SerializeField] private float _shootForce;
    [SerializeField] private float _timeBetweenShooting;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _shootSpread;
    [SerializeField] private int _magazineSize;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _attackPoint;

    private int _bulletsLeft;
    private int _bulletsShot;

    private float _spread;

    private bool _isReadyToShoot;
    private bool _isReloading;
    private bool _isShooting;
    private bool _allowButtonHold;

    private void Awake()
    {
        _bulletsLeft = _magazineSize;
        _isReadyToShoot = true;
    }

    private void Update()
    {
        if (_allowButtonHold)
            _isShooting = Input.GetMouseButtonDown(0);
        else
            _isShooting = Input.GetMouseButtonDown(0);

        if(_isReadyToShoot && _isShooting && !_isReloading && _bulletsLeft > 0)
        {
            _bulletsShot = 0;
            Shoot();
        }
    }

    private void Shoot()
    {
        _isReadyToShoot = false;

        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
        RaycastHit hit;
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        Vector3 directionWithoutSpread = targetPoint - _attackPoint.position;

        float xSpread = Random.Range(-_spread, _spread);
        float ySpread = Random.Range(-_spread, _spread);

        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(xSpread, ySpread, 0);
        _bulletsLeft--;
        _bulletsShot++;
    }

    private IEnumerator Reload()
    {
        _isReloading = true;
        var newWaitForSeconds = new WaitForSeconds(_reloadTime);

        yield return newWaitForSeconds;

        _bulletsLeft = _magazineSize;

        _isReloading = false;
    }
}
