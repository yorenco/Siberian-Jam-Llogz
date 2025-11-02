using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField] private LevelSession _levelSession;
    [SerializeField] private PlayerHealth _playerHealth;
    
    private void OnEnable()
    {
        _playerHealth.OnPlayerDeath += HandlePlayerDeath;
    }
    
    private void OnDisable()
    {
        _playerHealth.OnPlayerDeath -= HandlePlayerDeath;
    }
    
    private void HandlePlayerDeath()
    {
        _levelSession.OnPlayerDeath();
    }
}
