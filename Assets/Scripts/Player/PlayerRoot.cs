using UnityEngine;

[RequireComponent(typeof(IPlayerInput))]
public class PlayerRoot : MonoBehaviour
{
    private IPlayerInput _playerInput;


    private void Awake()
    {
        _playerInput = GetComponent<IPlayerInput>();

    }

    private void Update()
    {
        UpdateMovement();
    }
    
    private void UpdateMovement()
    {

        if (_playerInput.JumpInput)
            Debug.Log("Jump");
        
        if (_playerInput.SitDownInput)
            Debug.Log("SitDown");
    }
}