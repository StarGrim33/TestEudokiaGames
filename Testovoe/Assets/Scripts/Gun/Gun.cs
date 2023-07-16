using System.Collections;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunBullet _bulletPrefab;
    [SerializeField] private float _shootForce;
    [SerializeField] private float _timeBetweenShooting;
    [SerializeField] private float _reloadTime;
    [SerializeField] private int _magazineSize;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private GameObject _muzzleFlash;
    [SerializeField] private TMP_Text _muzzleText;

    private int _bulletsLeft;
    private int _bulletsShot;

    private bool _isReadyToShoot;
    private bool _isReloading;
    private bool _isShooting;
    private bool _allowButtonHold = true;

    private void Awake()
    {
        _bulletsLeft = _magazineSize;
        _isReadyToShoot = true;
    }

    private void Update()
    {
        if (_allowButtonHold)
            _isShooting = Input.GetMouseButton(0);
        else
            _isShooting = Input.GetMouseButtonDown(0);

        if (Input.GetKeyDown(KeyCode.R) && _bulletsLeft < _magazineSize && !_isReloading)
            StartCoroutine(ReloadRoutine());

        if (_isReadyToShoot && _isShooting && !_isReloading && _bulletsLeft <= 0)
            StartCoroutine(ReloadRoutine());

        if (_isReadyToShoot && _isShooting && !_isReloading && _bulletsLeft > 0)
        {
            _bulletsShot = 0;
            StartCoroutine(Shooting());
        }

        _muzzleText.text = _bulletsLeft.ToString();
    }

    private IEnumerator Shooting()
    {
        _isReadyToShoot = false;

        var currentBullet = Instantiate(_bulletPrefab, _attackPoint.position, Quaternion.identity);
        currentBullet.GetComponent<Rigidbody>().AddForce(_attackPoint.forward * _shootForce, ForceMode.Impulse);

        if (_muzzleFlash != null)
            Instantiate(_muzzleFlash, _attackPoint);

        _bulletsLeft--;
        _bulletsShot++;

        yield return new WaitForSeconds(_timeBetweenShooting);

        _isReadyToShoot = true;
    }

    private IEnumerator ReloadRoutine()
    {
        _isReloading = true;

        yield return new WaitForSeconds(_reloadTime);

        _bulletsLeft = _magazineSize;
        _isReloading = false;
    }
}
