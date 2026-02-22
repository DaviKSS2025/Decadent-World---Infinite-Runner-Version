using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{
    public PlayerAttackingState(PlayerController context) : base(context) { }

    public override void OnEnter()
    {
        player.PlayerAnimatorController.PlayAttack();
        player.AudioManager.PlayAttackSFX();
    }

    public override void OnUpdate()
    {
    }

    public override void OnExit()
    {
    }

    public override void HandleAnimationEvent(string eventName) 
    { 
        if (eventName == "StartAttack")
        {
            player.AttackHitbox.SetActive(true);
        }
        else if (eventName == "AttackEnd")
        {
            player.ChangeState(new PlayerGroundedState(player));
        }
    }
}
