using UnityEngine;

public class PlayerMovement
{

    //class to control the player RigidBody!

    private Rigidbody2D _rigidBody;
    private float _jumpForce = 7f;
    private float _fastFallAcceleration = 0.02f;
    private float _normalGravity;
    public void Initialize(Rigidbody2D rigidBody2D)
    {
        _rigidBody = rigidBody2D;
        _normalGravity = _rigidBody.gravityScale;
    }
    public void ApplyJump()
    {
        _rigidBody.linearVelocityY = 0;
        Vector2 jump = new Vector2(0, _jumpForce);
        _rigidBody.AddForce(jump, ForceMode2D.Impulse);
    }
    public void FastFalling()
    {
        _rigidBody.gravityScale += _fastFallAcceleration;
    }
    public void ResetGravity()
    {
        _rigidBody.gravityScale = _normalGravity;
    }
}
