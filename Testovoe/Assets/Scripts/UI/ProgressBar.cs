using System;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private EnemyCounter _enemyCounter;

    private void OnEnable()
    {
        _enemyCounter.EnemyCountChanged += OnEnemyCountChanged;
        _slider.value = 0;
    }

    private void OnEnemyCountChanged(int value, int maxValue)
    {
        _slider.value = (float)value / maxValue;
    }
}
