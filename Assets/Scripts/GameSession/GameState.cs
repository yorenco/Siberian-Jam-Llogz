using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }
    public static GameSaverLoader GameSaverLoader = new ();
    
    [SerializeField] private int _currentLevel = 1;
    
    public int CurrentLevel => _currentLevel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetLevel(int level)
    {
        _currentLevel = level;
        SaveGame();
        Debug.Log($"Уровень установлен: {_currentLevel}");
    }

    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(_currentLevel);
    }
    
    public void SaveGame()
    {
        GameSaverLoader.SaveGame(this);
    }
    
    public void LoadGame()
    {
        GameSaverLoader.LoadGame(this);
    }
}
