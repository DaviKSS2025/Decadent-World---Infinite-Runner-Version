using UnityEngine;

public class FireballAnimatorController
{
    private Animator _animator;

    private static readonly int Explosion = Animator.StringToHash("Explosion");
    public void Initialize(Animator animatorController)
    {
        _animator = animatorController;
    }

    public void PlayExplosion()
    {
        _animator.SetTrigger(Explosion);
    }
}
