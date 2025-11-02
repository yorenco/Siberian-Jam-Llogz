using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBootLoader : MonoBehaviour
{
    [SerializeField] private GameState _gameState;

    private const int FirstLevel = 1;

    private void Start()
    {
        _gameState.LoadGame();

        if (_gameState.CurrentLevel == 0)
            _gameState.SetLevel(FirstLevel);
        
        _gameState.LoadCurrentLevel();
    }
}