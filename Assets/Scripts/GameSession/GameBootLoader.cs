using UnityEngine;

public class GameBootLoader : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private int _testLevel = 1;

    private const int FirstLevel = 1;

    private void Start()
    {
        
        _gameState.LoadGame();

        if (_gameState.CurrentLevel == 0)
            _gameState.SetLevel(FirstLevel);

#if UNITY_EDITOR
        _gameState.SetLevel(_testLevel);
#endif
        
        _gameState.LoadCurrentLevel();
    }
}