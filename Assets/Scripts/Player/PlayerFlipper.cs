using UnityEngine;

[RequireComponent(typeof(PlayerMovementSimple), typeof(Transform))]
public class PlayerFlipper : MonoBehaviour
{
    [SerializeField] private IPlayerMovement _playerMovement;
    [SerializeField] private Transform _transform;
    
    private const int _forwardRotation = 0;
    private const int _backwardRotation = 180;

    private void Awake()
    {
        _playerMovement = GetComponent<IPlayerMovement>();
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (_playerMovement.Speed > 0)
            SetRotationY(_forwardRotation);
        else if (_playerMovement.Speed < 0)
            SetRotationY(_backwardRotation);
    }

    private void SetRotationY(int rotationY)
    {
        _transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
