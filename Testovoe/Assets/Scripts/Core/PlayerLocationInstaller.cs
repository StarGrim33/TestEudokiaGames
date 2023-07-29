using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class PlayerLocationInstaller : MonoInstaller
{
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private GameObject _playerPrefab;

    public override void InstallBindings()
    {
        //Player playerInstance = Container.InstantiatePrefabForComponent<Player>(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity, null);
        //Container.Bind<Player>().FromInstance(playerInstance).AsSingle().NonLazy();
    }
}
