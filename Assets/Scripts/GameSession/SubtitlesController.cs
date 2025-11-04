using UnityEngine;

public sealed class SubtitlesController
{
    private static SubtitlesController _instance;
    public static SubtitlesController Instance => _instance ??= new SubtitlesController();

    private SubtitleView _view;

    private SubtitlesController() { }

    public void RegisterView(SubtitleView view)
    {
        _view = view;
    }

    public void Show(string text, float duration = 3f)
    {
        if (_view == null)
        {
            Debug.LogWarning("SubtitleView не зарегистрирован!");
            return;
        }

        _view.Show(text, duration);
    }
}