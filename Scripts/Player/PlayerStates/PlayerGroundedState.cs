using UnityEngine;

public class PlayerGroundedState : PlayerBaseState
{
    public PlayerGroundedState(PlayerController context) : base(context) { }

    public override void OnEnter()
    {
        player.PlayerAnimatorController.PlayWalk();
    }

    public override void OnUpdate()
    {
        if (player.PlayerInputReader.JumpPressed)
        {
            player.ChangeState(new PlayerJumpingState(player));
        }
        else if (player.PlayerInputReader.AttackPressed)
        {
            player.ChangeState(new PlayerAttackingState(player));
        }
    }

    public override void OnExit()
    {
    }

    public override void HandleAnimationEvent(string eventName)
    {
    }
}
