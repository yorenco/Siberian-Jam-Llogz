using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Vector2 _offset = new Vector2(0f, -1f);
    [SerializeField] private Vector2 _size = new Vector2(2f, 0.1f);
    [SerializeField] private LayerMask _groundLayer;

    [Header("Debug")] [SerializeField] private bool _drawGizmos;

    private Vector3 _offset3D;

    public bool IsGrounded => CheckGrounded();

    private void Awake()
    {
        _offset3D = new Vector3(_offset.x, _offset.y, 0);
    }

    private bool CheckGrounded()
    {
        Collider2D overlappedCollider = Physics2D.OverlapBox(transform.position + _offset3D, _size, 0f,_groundLayer);
        return overlappedCollider != null;
    }
    
#if UNITY_EDITOR    
    private void OnDrawGizmosSelected()
    {
        if (!_drawGizmos)
            return;

        Vector2 checkPosition = (Vector2)transform.position + _offset;
        
        Gizmos.color = IsGrounded ? Color.yellow : Color.red;
        Gizmos.DrawWireCube(checkPosition, _size);
    }
#endif    
}