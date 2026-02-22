using UnityEngine;

public class ExitButton : MenuBaseButton
{
    private Animator _animator;

    private static int Playing = Animator.StringToHash("Playing");
    private static int Idle = Animator.StringToHash("Idle");
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void OnMouseHover()
    {
        _animator.SetTrigger(Playing);
    }
    public void OnMouseExit()
    {
        _animator.SetTrigger(Idle);
    }
    public override void OnClicked()
    {
        _SFXchannel?.RaiseEvent(_clickSound);
        Application.Quit();
    }
}
