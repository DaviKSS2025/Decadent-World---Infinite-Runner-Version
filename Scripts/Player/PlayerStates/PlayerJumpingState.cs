using UnityEngine;

public class PlayerJumpingState : PlayerBaseState
{
    public PlayerJumpingState(PlayerController context) : base(context) { }

    public override void OnEnter()
    {
        player.PlayerMovement.ApplyJump();
        player.PlayerAnimatorController.PlayJump();
        player.AudioManager.PlayJumpSFX();
    }
    public override void OnUpdate()
    {
        if (player.PlayerInputReader.FastFallPressed)
        {
            player.PlayerMovement.FastFalling();
        }
        // Fall animation
        if (player.RigidBody.linearVelocityY < 0)
        {
            player.ChangeState(new PlayerFallState(player));
        }
    }
    public override void OnExit()
    {
    }
    public override void HandleAnimationEvent(string eventName)
    {
    }
}
