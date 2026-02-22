using UnityEngine;

public abstract class PlayerBaseState : IPlayerState
{
    protected PlayerController player;

    public PlayerBaseState(PlayerController context)
    {
        this.player = context;
    }

    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();

    public virtual void HandleAnimationEvent(string eventName)
    {
    }
}
