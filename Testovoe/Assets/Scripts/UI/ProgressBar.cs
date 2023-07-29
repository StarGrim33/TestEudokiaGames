using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private EnemyCounter _enemyCounter;

    private void OnEnable()
    {
        _enemyCounter.EnemyCountChanged += OnEnemyCountChanged;
        _slider.value = 0;
    }

    [Inject]
    public void Construct(Slider slider, EnemyCounter enemyCounter)
    {
        _slider = slider;
        _enemyCounter = enemyCounter;
    }

    private void OnEnemyCountChanged(int value, int maxValue)
    {
        _slider.value = (float)value / maxValue;
    }
}
