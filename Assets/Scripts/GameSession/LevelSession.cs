using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSession : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _deathMenu;

    private bool _isPaused;
    private float _timeScaleNorm = 1f;
    private float _timeScalePause = 0f;

    private void Awake()
    {
        Time.timeScale = _timeScaleNorm;
        _pauseMenu?.SetActive(false);
        _deathMenu?.SetActive(false);
    }
    
    public void Pause()
    {
        if(_isPaused)
            return;
        
        _isPaused = true;
        Time.timeScale = _timeScalePause;
        _pauseMenu?.SetActive(true);
    }
    
    public void Resume()
    {
        if(_isPaused == false)
            return;
        
        _isPaused = false;
        Time.timeScale = _timeScaleNorm;
        _pauseMenu?.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = _timeScaleNorm;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void OnPlayerDeath()
    {
        Time.timeScale = _timeScalePause;
        _deathMenu?.SetActive(true);
    }
}
