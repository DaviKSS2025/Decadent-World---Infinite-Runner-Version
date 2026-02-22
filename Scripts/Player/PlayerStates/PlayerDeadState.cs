using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    public PlayerDeadState(PlayerController context) : base(context) { }

    public override void OnEnter()
    {
        // Player death animation
        player.PlayerAnimatorController.PlayDeath();
        player.AudioManager.PlayDeathSFX();
    }

    public override void OnUpdate()
    {
    }

    public override void OnExit()
    {
        // Final state.
    }

    public override void HandleAnimationEvent(string eventName) { }
}
