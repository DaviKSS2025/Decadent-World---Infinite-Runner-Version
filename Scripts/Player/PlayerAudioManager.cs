using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField] private SimpleAudioEvent _playerJumpSFX;
    [SerializeField] private SimpleAudioEvent _playerDeathSFX;
    [SerializeField] private SimpleAudioEvent _playerFallOnGroundSFX;
    [SerializeField] private SimpleAudioEvent _playerAttackSFX;
    [SerializeField] private SFXChannel _SFXChannel;
    
    public void PlayJumpSFX()
    {
        _SFXChannel.RaiseEvent(_playerJumpSFX);
    }
    public void PlayDeathSFX()
    {
        _SFXChannel.RaiseEvent(_playerDeathSFX);
    }
    public void PlayGroundSFX()
    {
        _SFXChannel.RaiseEvent(_playerFallOnGroundSFX);
    }
    public void PlayAttackSFX()
    {
        _SFXChannel.RaiseEvent(_playerAttackSFX);
    }
}
