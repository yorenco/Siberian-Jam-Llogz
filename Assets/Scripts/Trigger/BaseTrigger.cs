using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class BaseTrigger : MonoBehaviour, ITrigger
{
    [Tooltip("Требуется ли повторное срабатывание")]
    [SerializeField] private bool _canRepeat;

    private bool _isActivated;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<PlayerRoot>(out _) == false)
            return;

        if ((_canRepeat == false) && _isActivated)
            return;

        _isActivated = true;
        Activate();
    }

    public abstract void Activate();
}
