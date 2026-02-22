using UnityEngine;

public class PlayerAnimatorController
{
    private readonly Animator _animator;

    // Cached animator parameter hashes to avoid string lookups at runtime

    private static readonly int Walking = Animator.StringToHash("Walking");
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int Fall = Animator.StringToHash("Fall");
    private static readonly int Die = Animator.StringToHash("Die");
    private static readonly int Attack = Animator.StringToHash("Attack");


    //Class to ONLY affect player animations and Animator Parameters
    public PlayerAnimatorController(Animator animator)
    {
        _animator = animator;
    }
    public void PlayWalk()
    {
        _animator.ResetTrigger(Fall);
        _animator.SetTrigger(Walking);
    }
    public void PlayJump()
    {
        _animator.ResetTrigger(Walking);
        _animator.SetTrigger(Jump);
    } 
    public void PlayFall() 
    {
        _animator.ResetTrigger(Jump);
        _animator.SetTrigger(Fall);
    }
    public void PlayDeath()
    {
        _animator.SetTrigger(Die);
    }
    public void PlayAttack()
    {
        _animator.SetTrigger(Attack);
    }
}
