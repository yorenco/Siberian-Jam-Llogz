public interface IPlayerMovement : IJumper
{
    void Move(float horizontalSpeed);
    
    float Speed { get; }
    bool IsGrounded { get; }
    bool IsRightWallTouched { get; }
    bool IsLeftWallTouched { get; }
}