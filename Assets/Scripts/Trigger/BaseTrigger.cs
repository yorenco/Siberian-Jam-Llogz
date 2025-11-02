using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class BaseTrigger : MonoBehaviour, ITrigger
{
    [Tooltip("Требуется ли повторное срабатывание")]
    [SerializeField] private bool _canRepeat;
    
    protected Collider2D Collider;
    
    private bool _isActivated;
    private bool _isColliderVisible;

    private void Awake()
    {
        Collider = GetComponent<Collider2D>();
    }

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

    public virtual void SetCollidersVisibility(bool visibility)
    {
        _isColliderVisible = visibility;
    }
    
    private void OnDrawGizmos()
    {
        if (_isColliderVisible == false)
            return;
        
        Gizmos.color = Color.green;
        Vector3 center = transform.position + new Vector3(Collider.offset.x, Collider.offset.y, 0);
        Vector3 size = new Vector3(Collider.bounds.size.x, Collider.bounds.size.y, 0);
        Gizmos.DrawWireCube(center, size);
    }
}
