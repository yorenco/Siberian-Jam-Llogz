using UnityEngine;
using System.Collections;

public class ParticleGradientSwitcher : MonoBehaviour
{
    [Header("Target Particle System")]
    public ParticleSystem ps;

    [Header("Switching")]
    [Tooltip("Период переключения, сек.")]
    public float switchInterval = 2f;
    [Tooltip("Если включён Color over Lifetime, менять его; иначе Start Color.")]
    public bool preferColorOverLifetime = true;

    [Header("Green Settings")]
    public Color targetGreen = Color.green;

    private Gradient _originalGrad;
    private Gradient _greenGrad;
    private bool _isGreen;

    private void Awake()
    {
        if (ps == null) ps = GetComponent<ParticleSystem>();
        // Считываем реальный источник цвета по состоянию модулей прямо сейчас
        bool useCOL = preferColorOverLifetime && ps.colorOverLifetime.enabled;
        var src = useCOL ? ps.colorOverLifetime.color : ps.main.startColor;

        _originalGrad = ExtractSingleGradient(src);
        _greenGrad = MakeGreenified(_originalGrad, targetGreen);
    }

    private void OnEnable()
    {
        StartCoroutine(SwitchLoop());
    }

    private IEnumerator SwitchLoop()
    {
        // Начинаем с оригинального
        ApplyGradient(_originalGrad);

        var wait = new WaitForSeconds(switchInterval);
        while (true)
        {
            yield return wait;
            _isGreen = !_isGreen;
            ApplyGradient(_isGreen ? _greenGrad : _originalGrad);
        }
    }

    private void ApplyGradient(Gradient g)
    {
        // Каждый раз берём актуальные модули (не кэшируем)
        bool useCOL = preferColorOverLifetime && ps.colorOverLifetime.enabled;
        var mmg = new ParticleSystem.MinMaxGradient(CloneGradient(g));

        if (useCOL)
        {
            var col = ps.colorOverLifetime; // struct-обёртка, но присваивание – «внутрь системы»
            col.enabled = true;             // гарантируем включение
            col.color = mmg;                // переустановили
            // Фикс на редкий баг «не перекрашивается»: мигнём включением
            // (закомментируй, если не требуется)
            // col.enabled = false; col.enabled = true;
        }
        else
        {
            var main = ps.main;             // struct-копия; менять через локал
            main.startColor = mmg;
        }
    }

    /* ---------- helpers ---------- */

    private static Gradient ExtractSingleGradient(ParticleSystem.MinMaxGradient src)
    {
        switch (src.mode)
        {
            case ParticleSystemGradientMode.Gradient: return CloneGradient(src.gradient);
            case ParticleSystemGradientMode.TwoGradients: return CloneGradient(src.gradientMax);
            case ParticleSystemGradientMode.Color:
            case ParticleSystemGradientMode.TwoColors:
            case ParticleSystemGradientMode.RandomColor:
            default:
                Color c = (src.mode == ParticleSystemGradientMode.TwoColors) ? src.colorMax : src.color;
                var g = new Gradient();
                g.SetKeys(
                    new[] { new GradientColorKey(c, 0f), new GradientColorKey(c, 1f) },
                    new[] { new GradientAlphaKey(c.a, 0f), new GradientAlphaKey(c.a, 1f) }
                );
                return g;
        }
    }

    private static Gradient MakeGreenified(Gradient src, Color greenRef)
    {
        Color.RGBToHSV(greenRef, out float hGreen, out _, out _);
        var srcCK = src.colorKeys;
        var srcAK = src.alphaKeys;

        var newCK = new GradientColorKey[srcCK.Length];
        for (int i = 0; i < srcCK.Length; i++)
        {
            var c = srcCK[i].color;
            Color.RGBToHSV(c, out _, out float s, out float v);
            var greenish = Color.HSVToRGB(hGreen, s, v);
            greenish.a = c.a; // пусть альфа узла останется как была
            newCK[i] = new GradientColorKey(greenish, srcCK[i].time);
        }

        var g = new Gradient();
        g.SetKeys(newCK, srcAK);
        return g;
    }

    private static Gradient CloneGradient(Gradient src)
    {
        var g = new Gradient();
        g.SetKeys(src.colorKeys, src.alphaKeys);
        return g;
    }
}
