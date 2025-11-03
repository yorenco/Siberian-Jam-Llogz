public interface IPlayerMovement : IJumper
{
    void Move(float horizontalSpeed);
    void SitDown();
    void StandUp();
    
    float Speed { get; }
    bool IsGrounded { get; }
    bool IsRightWallTouched { get; }
    bool IsLeftWallTouched { get; }
}