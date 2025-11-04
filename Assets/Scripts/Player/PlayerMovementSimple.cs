using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(GroundChecker), typeof(WallChecker))]
public class PlayerMovementSimple : MonoBehaviour, IPlayerMovement
{
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private WallChecker _wallChecker;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpForce = 1.5f;
    [SerializeField] private float _speedMax = 5f;
    [SerializeField] private float _sitDownScale = 0.5f;
    [SerializeField] private float _standUpScale = 1f;

    private float _currentSpeed;
    
    public float Speed => _currentSpeed;
    public bool IsGrounded => _groundChecker.IsGrounded;
    public bool IsRightWallTouched => _wallChecker.IsRightWallTouched;
    public bool IsLeftWallTouched => _wallChecker.IsLeftWallTouched;

    private void Awake()
    {
        _groundChecker = GetComponent<GroundChecker>();
        _wallChecker = GetComponent<WallChecker>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float horizontalSpeed)
    {
        Vector2 velocity = _rigidbody.linearVelocity;
        
        if (horizontalSpeed > 0 && _wallChecker.IsRightWallTouched == false)
            velocity.x = _speedMax * horizontalSpeed;
        else if(horizontalSpeed < 0 && _wallChecker.IsLeftWallTouched == false)
            velocity.x = _speedMax * horizontalSpeed;
        else
            velocity.x = 0;
        
        _currentSpeed = velocity.x;
        
        _rigidbody.linearVelocity = velocity;
    }

    public void Jump()
    {
        if (_groundChecker.IsGrounded == false)
        {
            Debug.Log("Not Grounded");
            return;
        }

        Vector2 velocity = _rigidbody.linearVelocity;
        velocity.y += _jumpForce;
        _rigidbody.linearVelocity = velocity;
    }
    
    public void SitDown()
    {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, _sitDownScale, gameObject.transform.localScale.z);
        _wallChecker.SetSizeCoefficients(new Vector2(1, _sitDownScale));
    }
    
    public void StandUp()
    {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, _standUpScale, gameObject.transform.localScale.z);
        _wallChecker.SetSizeCoefficients(new Vector2(1, _standUpScale));
    }
}