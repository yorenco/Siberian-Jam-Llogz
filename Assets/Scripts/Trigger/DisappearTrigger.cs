using UnityEngine;

public class DisappearTrigger : BaseTrigger
{
    [SerializeField] private GameObject _target;

    // Новые поля
    [SerializeField] private bool _initializeOnEnable = true;
    [SerializeField] private bool _initialActiveState = true; // как раньше: стартуем видимым

    private void OnEnable()
    {
        if (_target == null)
            throw new System.ArgumentNullException(nameof(gameObject) + " has no target");

        if (_initializeOnEnable)
            _target.SetActive(_initialActiveState);
    }

    public override void Activate()
    {
        _target.SetActive(false);
    }
}
