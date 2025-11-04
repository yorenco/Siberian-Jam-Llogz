using UnityEngine;
using TMPro;
using System.Collections;

public class SubtitleView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI subtitleText;
    [SerializeField] private CanvasGroup canvasGroup;

    private Coroutine _currentCoroutine;

    private void Awake()
    {
        SubtitlesController.Instance.RegisterView(this);
        canvasGroup.alpha = 0;
    }

    public void Show(string text, float duration)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(ShowRoutine(text, duration));
    }

    private IEnumerator ShowRoutine(string text, float duration)
    {
        subtitleText.text = text;

        // плавное появление
        for (float t = 0; t < 1f; t += Time.deltaTime * 4f)
        {
            canvasGroup.alpha = t;
            yield return null;
        }
        canvasGroup.alpha = 1f;

        yield return new WaitForSeconds(duration);

        // плавное исчезновение
        for (float t = 1f; t > 0f; t -= Time.deltaTime * 4f)
        {
            canvasGroup.alpha = t;
            yield return null;
        }
        canvasGroup.alpha = 0;
    }
}