using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public PlayerFallState(PlayerController context) : base(context) { }

    public override void OnEnter()
    {
        player.PlayerAnimatorController.PlayFall();
    }
    public override void OnUpdate()
    {
        if (player.PlayerInputReader.FastFallPressed)
        {
            player.PlayerMovement.FastFalling();
        }

        if (player.IsGrounded)
        {
            player.ChangeState(new PlayerGroundedState(player));
        }
    }
    public override void OnExit()
    {
        player.PlayerMovement.ResetGravity();
    }

    public override void HandleAnimationEvent(string eventName)
    {
    }
}
