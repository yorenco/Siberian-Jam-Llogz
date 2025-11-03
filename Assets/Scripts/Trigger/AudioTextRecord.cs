using System;
using UnityEngine;

[Serializable]
public class AudioTextRecord
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private string _text;
    [SerializeField] private float _timeText;
    
    public AudioClip Clip => _clip;
    public string Text => _text;
    public float TimeText => _timeText;
}
