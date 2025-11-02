using UnityEngine;

public class MoveTrigger : BaseTrigger
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _destination;
    [SerializeField] private float _speed = 2f;

    private bool _isMoving;
    
    private void OnEnable()
    {
        if (_target == null)
            throw new System.ArgumentNullException(nameof(gameObject) + " has no target");
        
        if (_destination == null)
            throw new System.ArgumentNullException(nameof(gameObject) + " has no destination");
    }

    public override void Activate()
    {
        if (_target == null) return;
        if (_isMoving) return;

        _isMoving = true;
        StartCoroutine(MoveCoroutine());
    }

    private System.Collections.IEnumerator MoveCoroutine()
    {
        Vector3 start = _target.position;
        Vector3 end = _destination.position;
        float time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime * _speed;
            _target.position = Vector3.Lerp(start, end, time);
            yield return null;
        }
    }
}