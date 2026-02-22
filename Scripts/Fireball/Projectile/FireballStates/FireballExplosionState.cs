using UnityEngine;

public class FireballExplosionState : FireballBaseState
{
    public FireballExplosionState(FireballController context) : base(context) { }
    public override void OnEnter()
    {
        controller.Movement.HorizontalMovement(0);
        controller.AnimatorController.PlayExplosion();
        controller.AudioManager.PlayExplosion();
    }
    public override void OnUpdate()
    {

    }
    public override void OnExit()
    {

    }
    public override void HandleAnimationEvent(string eventName)
    {
        if (eventName == "ExplosionEnd")
        {
            controller.AutoDisable();
        }
    }
}
