using UnityEngine;

public class FireballTravelingState : FireballBaseState
{
    public FireballTravelingState(FireballController context) : base(context) { }
    public override void OnEnter()
    {
        float speed = Random.Range(-3f, -6f);
        controller.Movement.HorizontalMovement(speed);
    }
    public override void OnUpdate()
    {

    }
    public override void OnExit()
    {

    }
    public override void HandleAnimationEvent(string eventName)
    {
    }
}
