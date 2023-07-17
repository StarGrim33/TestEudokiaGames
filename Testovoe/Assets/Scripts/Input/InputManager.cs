using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMotor))]
public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerInput.OnFootActions _onFoot;
    private PlayerMotor _playerMotor;
    private PlayerLook _playerLook;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _onFoot = _playerInput.OnFoot;
        _playerMotor = GetComponent<PlayerMotor>();
        _onFoot.Jump.performed += ctx => _playerMotor.Jump();
        _playerLook = GetComponent<PlayerLook>(); 
        StateManager.Instance.OnGameStateChange += OnGameStateChange;

    }

    private void OnGameStateChange(GameState newGameState)
    {
        enabled = newGameState == GameState.Gameplay;
    }

    private void OnDestroy()
    {
        StateManager.Instance.OnGameStateChange -= OnGameStateChange;
    }

    private void FixedUpdate()
    {
        if (_playerMotor != null)
            _playerMotor.MoveProcess(_onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        if( _playerLook != null)
            _playerLook.ProcessLook(_onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        _onFoot.Enable();
    }

    private void OnDisable()
    {
        _onFoot.Disable();
    }
}
