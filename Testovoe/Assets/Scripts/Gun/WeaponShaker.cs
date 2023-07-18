using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShaker : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;

    public void DoShake()
    {
        _cameraTransform.DOShakePosition(0.05f, 0.2f, 10, 90f, false, true, ShakeRandomnessMode.Harmonic).SetEase(Ease.InOutBounce).SetLink(_cameraTransform.gameObject);
        _cameraTransform.DOShakeRotation(0.05f, 0.2f, 10, 90f, true, ShakeRandomnessMode.Harmonic).SetEase(Ease.InOutBounce).SetLink(_cameraTransform.gameObject);
    }
}
