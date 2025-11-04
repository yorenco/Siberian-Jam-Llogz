using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioTrigger : BaseTrigger
{
    [SerializeField] private AudioTextRecord[] _records;
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public override void Activate()
    {
        if (_records == null || _records.Length == 0) 
            return;
        
        AudioTextRecord record = _records[Random.Range(0, _records.Length)];
        AudioClip clip = record.Clip;
        _audio.PlayOneShot(clip);
        SubtitlesController.Instance.Show(record.Text);
    }
}