using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightSetter : MonoBehaviour
{
    [SerializeField] private Light2D _globalLight;
    [SerializeField] private float _lightIntensityOn;
    [SerializeField] private float _lightIntensityOff;
    
    
    private void Start()
    {
        if(_globalLight == null)
            throw new ArgumentNullException("Has no component" + nameof(_globalLight));
        
        SetGlobalLight();
    }

    private void SetGlobalLight()
    {
        if (GameState.Instance.HasLightning)
        {
            _globalLight.intensity = _lightIntensityOn;
        }
        else
        {
            _globalLight.intensity = _lightIntensityOff;
        }
    }
}
