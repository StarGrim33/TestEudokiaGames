using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ProgressBarInstaller : MonoInstaller
{
    [SerializeField] private Slider _slider;
    [SerializeField] private EnemyCounter _enemyCounter;

    public override void InstallBindings()
    {
        Container.Bind<Slider>().FromInstance(_slider).AsSingle();
        Container.Bind<EnemyCounter>().FromInstance(_enemyCounter).AsSingle();
    }
}
