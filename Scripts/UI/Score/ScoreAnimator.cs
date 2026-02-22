using UnityEngine;

public class ScoreAnimator
{
    private Animator _animator;

    private static readonly int Playing = Animator.StringToHash("Playing");
    public void Initialize(Animator animator)
    {
        _animator = animator;
    }
    public void PlayingScore()
    {
        _animator.SetTrigger(Playing);
    }
}
