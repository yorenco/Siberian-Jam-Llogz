using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    private const int FirstLevel = 1;
    
    public static GameState Instance { get; private set; }
    private static readonly GameSaverLoader s_gameSaverLoader = new();

    [SerializeField] private int _currentLevel = 1;
    [SerializeField] private bool _hasLightning;
    [SerializeField] private bool _hasDrawingColliders;
    [SerializeField] private int _maxLevel = 2;
    [SerializeField] private float _volume = 0.8f;

    public int CurrentLevel => _currentLevel;
    public bool HasLightning => _hasLightning;
    public bool HasDrawingColliders => _hasDrawingColliders;
    
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

    public void SetFirstLevel()
    {
        SetLevel(FirstLevel);
    }

    public void GoToNextLevel()
    {
        if (_currentLevel >= _maxLevel)
        {
            SetFirstLevel();
            
            if (_hasLightning == false)
            {
                SetLightning();
            }
            else if (_hasDrawingColliders == false)
            {
                SetDrawingColliders();
            }
        }
        else
        {
            SetLevel(_currentLevel + 1);
        }

        LoadCurrentLevel();
    }

    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(_currentLevel);
    }

    public void LoadGame()
    {
        s_gameSaverLoader.LoadGame(this);
    }

    public void SetLightning()
    {
        _hasLightning = true;
        SaveGame();
    }

    public void SetDrawingColliders()
    {
        _hasDrawingColliders = true;
        SaveGame();
    }

    [ContextMenu("Reset Progress")]
    public void ResetProgress()
    {
        _currentLevel = 1;
        _hasLightning = false;
        _hasDrawingColliders = false;
        SaveGame();
    }

    private void SaveGame()
    {
        s_gameSaverLoader.SaveGame(this);
    }
}