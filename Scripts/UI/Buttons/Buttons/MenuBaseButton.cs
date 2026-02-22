using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Base class for menu buttons.
/// Handles common audio feedback and animation triggers.
/// Child classes may override behavior as needed.
/// </summary>

public abstract class MenuBaseButton : MonoBehaviour,IMenuButton
{
    [SerializeField] protected SFXChannel _SFXchannel;
    [SerializeField] protected SimpleAudioEvent _hoverSound;
    [SerializeField] protected SimpleAudioEvent _clickSound;
    [SerializeField] protected TargetScene _targetScene;

    public virtual void OnMouseHoverOrExit()
    {
        _SFXchannel?.RaiseEvent(_hoverSound);
    }
    public virtual void OnClicked()
    {
        _SFXchannel?.RaiseEvent(_clickSound);
        SceneManager.LoadScene(_targetScene.SceneName);
    }
}
