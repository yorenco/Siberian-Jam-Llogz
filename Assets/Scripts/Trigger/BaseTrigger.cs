using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class BaseTrigger : MonoBehaviour, ITrigger
{
    [Tooltip("Требуется ли повторное срабатывание")]
    [SerializeField] private bool _canRepeat;
    
    protected Collider2D Collider;
    
    private bool _isActivated;
    private ColliderOutlineDrawer _colliderOutlineDrawer;

    private void Awake()
    {
        
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
        Collider = GetComponent<Collider2D>();
        _colliderOutlineDrawer = new ColliderOutlineDrawer(Collider, Color.red);
        
        if(visibility)
            _colliderOutlineDrawer.Draw();
        else
            _colliderOutlineDrawer.Destroy();
    }
}
