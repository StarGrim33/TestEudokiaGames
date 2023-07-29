using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Spawner>().FromComponentInHierarchy().AsSingle();
    }
}
