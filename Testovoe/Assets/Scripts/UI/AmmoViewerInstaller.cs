using TMPro;
using UnityEngine;
using Zenject;

public class AmmoViewerInstaller : MonoInstaller
{
    [SerializeField] private TMP_Text _muzzleText;

    public override void InstallBindings()
    {
        Container.Bind<TMP_Text>().FromInstance(_muzzleText).AsSingle();
    }
}
