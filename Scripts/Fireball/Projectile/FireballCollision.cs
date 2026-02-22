using UnityEngine;

// Handles collision-based state transitions for the fireball.
// Keeps interaction rules isolated from movement and animation logic.
public class FireballCollision : MonoBehaviour
{
    private FireballController _controller;
    [SerializeField] private DamageChannel _damageChannel;

    public void Initialize(FireballController controller)
    {
        _controller = controller;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Transition to explosion state and notify damage system
            _controller.ChangeState(new FireballExplosionState(_controller));
            _damageChannel.RaisePlayerDamaged();
        }
        else if (collision.CompareTag("AttackHitbox"))
        {
            // Player attack reverses projectile direction
            _controller.ChangeState(new FireballReverseState(_controller));
        }
        else if (collision.CompareTag("Fireball"))
        {
            FireballController other = collision.GetComponent<FireballController>();

            if (other == null) return;

            bool thisIsReverse = _controller.CurrentState is FireballReverseState;
            bool otherIsReverse = other.CurrentState is FireballReverseState;

            // If either projectile is in reverse state, both explode on contact
            if (thisIsReverse || otherIsReverse)
            {
                _controller.ChangeState(new FireballExplosionState(_controller));
                other.ChangeState(new FireballExplosionState(other));
            }
        }
    }
}
