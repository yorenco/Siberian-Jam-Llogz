using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow2D : MonoBehaviour
{
    [Header("Основные настройки")]
    [SerializeField] private Transform _target;               
    [SerializeField] private float _smoothSpeed = 5f;        

    [Header("Зона допуска (в мире, в единицах Unity)")]
    [SerializeField] private float _xThreshold = 2f;          
    [SerializeField] private float _yThreshold = 1.5f;        
    
    [Header("Debug")]
    [SerializeField] private bool _drawGizmos;
    
    private Vector3 _targetPosition;                          
    private Camera _camera;
    
    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (_target == null)
            return;

        Vector3 cameraPosition = transform.position;
        Vector3 targetPosition = _target.position;

        bool needMoveX = Mathf.Abs(targetPosition.x - cameraPosition.x) > _xThreshold;
        bool needMoveY = Mathf.Abs(targetPosition.y - cameraPosition.y) > _yThreshold;

        if (needMoveX || needMoveY)
        {
            _targetPosition = new Vector3(
                needMoveX ? targetPosition.x : cameraPosition.x,
                needMoveY ? targetPosition.y : cameraPosition.y,
                cameraPosition.z
            );
        }

        transform.position = Vector3.Lerp(cameraPosition, _targetPosition, Time.deltaTime * _smoothSpeed);
        transform.position = new Vector3(transform.position.x, transform.position.y, cameraPosition.z);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if (_target == null || _drawGizmos == false)
            return;

        Gizmos.color = Color.yellow;

        Vector3 center = new Vector3(transform.position.x, transform.position.y, 0f);
        Vector3 size = new Vector3(_xThreshold * 2f, _yThreshold * 2f, 0f);
        Gizmos.DrawWireCube(center, size);
    }
#endif
}
