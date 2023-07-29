using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Zenject;

public class GunInstall : MonoInstaller
{
    [SerializeField] private AudioSource _source;

    public override void InstallBindings()
    {
        Container.Bind<AudioSource>().FromInstance(_source).AsSingle();
        Container.Bind<Gun>().FromComponentInHierarchy().AsSingle();
    }
}
