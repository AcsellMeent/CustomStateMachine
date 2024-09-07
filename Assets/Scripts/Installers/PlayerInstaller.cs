using Zenject;
using UnityEngine;
using System;
using Player;
using Cinemachine;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject _playerPrefab;

    [SerializeField]
    private Transform _playerSpawnPoint;

    [SerializeField]
    private CinemachineFreeLook _cinemachineFreeLook;

    public override void InstallBindings()
    {
        if (!_playerPrefab || !_playerSpawnPoint) throw new Exception("player prefab or spawn point not set");
        GameObject playerInstance = Container.InstantiatePrefab(_playerPrefab, _playerSpawnPoint.position, _playerSpawnPoint.rotation, null);

        Container.Bind<PlayerStateMachine>().FromComponentInHierarchy(playerInstance).AsSingle().NonLazy();

        playerInstance.GetComponent<PlayerLookToTarget>().CinemachineFreeLook = _cinemachineFreeLook;

        _cinemachineFreeLook.Follow = playerInstance.transform;
        _cinemachineFreeLook.LookAt = playerInstance.transform;
    }
}
