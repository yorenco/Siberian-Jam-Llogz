using UnityEngine;

public class GameSaverLoader
{
    public const string LevelTag = "Level";
    
    public void SaveGame(GameState gameState)
    {
        PlayerPrefs.SetInt(LevelTag, gameState.CurrentLevel);
    }
    
    public void LoadGame(GameState gameState)
    {
        int level = PlayerPrefs.GetInt(LevelTag);
        gameState.SetLevel(level);
    }
}
