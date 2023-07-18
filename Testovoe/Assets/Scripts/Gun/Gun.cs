using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunBullet _bulletPrefab;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private AudioSource _shotSound;
    [SerializeField] private TMP_Text _muzzleText;
    [SerializeField] private float _shootForce;
    [SerializeField] private float _timeBetweenShooting;
    [SerializeField] private float _reloadTime;
    [SerializeField] private int _magazineSize;
    [SerializeField] private WeaponShaker _weaponShaker;

    private int _bulletsLeft;
    private int _bulletsShot;

    private bool _isReadyToShoot;
    private bool _isReloading;
    private bool _isShooting;
    private bool _allowButtonHold = true;
    private float _baseTimeBetweenShooting;

    private void OnDestroy()
    {
        StateManager.Instance.OnGameStateChange -= OnGameStateChange;
    }

    private void OnGameStateChange(GameState newGameState)
    {
        enabled = newGameState == GameState.Gameplay;
    }

    private void Awake()
    {
        _bulletsLeft = _magazineSize;
        _isReadyToShoot = true;
        _baseTimeBetweenShooting = _timeBetweenShooting;
    }

    private void Start()
    {
        StateManager.Instance.OnGameStateChange += OnGameStateChange;
    }

    private void Update()
    {
        HandleShooting();
        HandleReloading();
        _muzzleText.text = _bulletsLeft.ToString();
    }

    public void IncreaseFireRate(float value, float duration)
    {
        if(value <= 0 || duration <= 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        Debug.Log("Incresead");
        _timeBetweenShooting = value;
        StartCoroutine(FireRateSmooth(duration));
    }

    public void UpgradeFireRate(float value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        _timeBetweenShooting -= value;
    }

    private IEnumerator FireRateSmooth(float duration)
    {
        var newWaitForSeconds = new WaitForSeconds(duration);
        yield return newWaitForSeconds;
        _timeBetweenShooting = _baseTimeBetweenShooting;
    }

    private void HandleShooting()
    {
        if (_allowButtonHold)
            _isShooting = Input.GetMouseButton(0);
        else
            _isShooting = Input.GetMouseButtonDown(0);

        if (_isReadyToShoot && _isShooting && !_isReloading && _bulletsLeft > 0)
        {
            _bulletsShot = 0;
            StartCoroutine(Shooting());
        }
    }

    private void HandleReloading()
    {
        if (Input.GetKeyDown(KeyCode.R) && _bulletsLeft < _magazineSize && !_isReloading)
            StartCoroutine(ReloadRoutine());

        if (_isReadyToShoot && _isShooting && !_isReloading && _bulletsLeft <= 0)
            StartCoroutine(ReloadRoutine());
    }

    private IEnumerator Shooting()
    {
        _isReadyToShoot = false;

        var currentBullet = Instantiate(_bulletPrefab, _attackPoint.position, Quaternion.identity);
        currentBullet.GetComponent<Rigidbody>().AddForce(_attackPoint.forward * _shootForce, ForceMode.Impulse);

        _shotSound.PlayOneShot(_shotSound.clip);
        _weaponShaker.DoShake();

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
