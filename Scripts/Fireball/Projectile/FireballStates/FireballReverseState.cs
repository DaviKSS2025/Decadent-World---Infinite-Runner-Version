using UnityEngine;

// State triggered when the projectile is reflected by the player.
// Changes direction, visual feedback, and collision behavior.
public class FireballReverseState : FireballBaseState
{
    public FireballReverseState(FireballController context) : base(context) { }

    private Color _originalColor;

    public override void OnEnter()
    {
        ReverseDirection();
        AdjustSprite();
    }
    public override void OnUpdate()
    {

    }
    public override void OnExit()
    {
        ResetBeforeExitState();
    }
    public override void HandleAnimationEvent(string eventName)
    {
    }

    private void AdjustSprite()
    {
        // Visual feedback to indicate reversed projectile
        controller.SpriteRenderer.flipX = true;
        _originalColor = controller.SpriteRenderer.color;
        controller.SpriteRenderer.color = Color.blue;
    }
    private void ResetBeforeExitState()
    {
        controller.SpriteRenderer.color = _originalColor;
        controller.SpriteRenderer.flipX = false;
    }
    private void ReverseDirection()
    {
        float speed = Random.Range(3f, 6f);
        controller.Movement.HorizontalMovement(speed);
    }

}
