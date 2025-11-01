using System;
using UnityEngine;

public class WallChecker : MonoBehaviour
{
    [SerializeField] private Vector2 _leftOffset = new Vector2(-1f, 0f);
    [SerializeField] private Vector2 _rightOffset = new Vector2(1f, 0f);
    [SerializeField] private Vector2 _size = new Vector2(0.1f, 1f);
    [SerializeField] private LayerMask _layerMask;

    [Header("Debug")] 
    [SerializeField] private bool _drawGizmos;

    private Vector3 _leftOffset3D;
    private Vector3 _rightOffset3D;
    
    public bool IsLeftWallTouched => CheckLeftWall();
    public bool IsRightWallTouched => CheckRightWall();

    private void Awake()
    {
        _leftOffset3D = new Vector3(_leftOffset.x, _leftOffset.y, 0);
        _rightOffset3D = new Vector3(_rightOffset.x, _rightOffset.y, 0);
    }
    
    private bool CheckLeftWall()
    {
        Collider2D colliderOverlapped = Physics2D.OverlapBox(transform.position + _leftOffset3D, _size, 0f, _layerMask);
        
        return colliderOverlapped != null;
    }    
    
    private bool CheckRightWall()
    {
        Collider2D colliderOverlapped = Physics2D.OverlapBox(transform.position + _rightOffset3D, _size, 0f, _layerMask);
        
        return colliderOverlapped != null;
    }
    
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if(_drawGizmos == false)
            return;
        
        Vector2 checkLeftPosition = (Vector2)transform.position + _leftOffset;
        Vector2 checkRightPosition = (Vector2)transform.position + _rightOffset;
        
        Gizmos.color = IsLeftWallTouched  ? Color.blue : Color.red;
        Gizmos.DrawWireCube(checkLeftPosition, _size);
        
        Gizmos.color = IsRightWallTouched  ? Color.green : Color.red;
        Gizmos.DrawWireCube(checkRightPosition, _size);
    }
#endif
}
