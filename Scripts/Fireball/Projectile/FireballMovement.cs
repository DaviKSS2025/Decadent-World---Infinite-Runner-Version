using UnityEngine;

public class FireballMovement
{
    private Rigidbody2D _rigidBody;
    public void Initialize(Rigidbody2D rigidBody)
    {
        _rigidBody = rigidBody;
    }

    public void HorizontalMovement(float speed)
    {
        _rigidBody.linearVelocityX = speed;
    }
}
