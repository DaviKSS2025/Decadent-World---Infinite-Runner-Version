using UnityEngine;

public abstract class FireballBaseState : IFireballState
{
    protected FireballController controller;

    public FireballBaseState(FireballController context)
    {
        this.controller = context;
    }

    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();

    public virtual void HandleAnimationEvent(string eventName)
    {
    }
}
