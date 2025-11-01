using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour, IPlayerInput
{
    private PlayerControls _controls;
    private float _moveInput;
    private bool _jumpPressed;
    private bool _sitDownPressed;

    private void Awake()
    {
        _controls = new PlayerControls();

        // Подписываемся на события ввода
        _controls.Player.Move.performed += OnMove;
        _controls.Player.Move.canceled += OnMoveCanceled;

        _controls.Player.Jump.performed += ctx => _jumpPressed = true;
        _controls.Player.SitDown.performed += ctx => _sitDownPressed = true;
    }

    private void OnEnable() => _controls.Enable();
    private void OnDisable() => _controls.Disable();

    private void OnMove(InputAction.CallbackContext ctx)
    {
        _moveInput = ctx.ReadValue<float>();
        Debug.Log(_moveInput);
    }

    private void OnMoveCanceled(InputAction.CallbackContext ctx)
    {
        _moveInput = 0.0f;
    }

    public float HorizontalInput => _moveInput;

    public bool JumpInput
    {
        get
        {
            bool wasPressed = _jumpPressed;
            _jumpPressed = false; // сбрасываем, чтобы кнопка реагировала как GetButtonDown
            return wasPressed;
        }
    }

    public bool SitDownInput
    {
        get
        {
            bool wasPressed = _sitDownPressed;
            _sitDownPressed = false; // сбрасываем, чтобы кнопка реагировала как GetButtonDown
            return wasPressed;
        }
    }
}