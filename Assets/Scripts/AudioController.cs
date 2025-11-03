using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    private const float SliderMinValue = 0.0001f;
    private const float SliderMaxValue = 1f;
    private const float VolumeMin = -80f;
    private const float VolumeConvertCoefficient = 20f;
    
    private const string VolumeKey = "Volume";

    [SerializeField] private AudioMixer AudioMixer;
    [SerializeField] private Slider VolumeSlider;
    [SerializeField] private string VolumeParameterName;

    private float Volume = 0.8f;

    private void Awake()
    {
        ValidateVolumeParameterNameIsSet();
        VolumeSlider.minValue = SliderMinValue;
        VolumeSlider.maxValue = SliderMaxValue;
        VolumeSlider.value = SliderMaxValue;
    }

    private void Start()
    {
        VolumeSlider.onValueChanged.AddListener(ChangeVolume);
        Volume = VolumeSlider.value = LoadVolume();
        ChangeVolume(Volume);
    }

    private void OnDestroy()
    {
        VolumeSlider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume(float volume)
    {
        Volume = volume;

        if (volume == 0)
            AudioMixer.SetFloat(VolumeParameterName, VolumeMin);
        else
            AudioMixer.SetFloat(VolumeParameterName, Mathf.Log10(Volume) * VolumeConvertCoefficient);
    }

    private void ValidateVolumeParameterNameIsSet()
    {
        if (VolumeParameterName == null)
        {
            Debug.LogError("Volume parameter name is null");
        }
    }
    
    private float LoadVolume()
    {   
        float result = PlayerPrefs.GetFloat(VolumeKey);
        
        if (result == 0)
            result = Volume;
        
        return result;
    }
    
    private void SaveVolume()
    {
        PlayerPrefs.SetFloat(VolumeKey, Volume);
    }
}