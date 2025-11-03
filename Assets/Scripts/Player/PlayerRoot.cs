using UnityEngine;

[RequireComponent(typeof(IPlayerInput), typeof(PlayerMovementSimple), typeof(AnimatorAdapter))]
public class PlayerRoot : MonoBehaviour
{
    private IPlayerInput _playerInput;
    private IPlayerMovement _playerMovement;
    private AnimatorAdapter _animatorAdapter;

    private void Awake()
    {
        _playerInput = GetComponent<IPlayerInput>();
        _playerMovement = GetComponent<IPlayerMovement>();
        _animatorAdapter = GetComponent<AnimatorAdapter>();
    }

    private void Update()
    {
        UpdateMovement();
        UpdateAnimation();
    }
    
    private void UpdateMovement()
    {
        _playerMovement.Move(_playerInput.HorizontalInput);

        if (_playerInput.JumpInput)
            _playerMovement.Jump();
        
        if (_playerInput.SitDownInput)
            _playerMovement.SitDown();
        else
            _playerMovement.StandUp();
    }
    
    private void UpdateAnimation()
    {
        _animatorAdapter.SetMovementAnimation(_playerMovement.Speed);
        _animatorAdapter.SetJumpAnimation(_playerMovement.IsGrounded);
    }
}