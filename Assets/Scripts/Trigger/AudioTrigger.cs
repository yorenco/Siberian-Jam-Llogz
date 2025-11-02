using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioTrigger : BaseTrigger
{
    [SerializeField] private AudioClip[] _clips;
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public override void Activate()
    {
        if (_clips == null || _clips.Length == 0) return;

        AudioClip clip = _clips[Random.Range(0, _clips.Length)];
        _audio.PlayOneShot(clip);
    }
}