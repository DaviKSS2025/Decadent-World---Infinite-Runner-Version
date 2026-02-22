using UnityEngine;

public class FireballAudioManager : MonoBehaviour
{
    [SerializeField] private SimpleAudioEvent _fireballExplosionSFX;
    [SerializeField] private SFXChannel _SFXChannel;
    
    public void PlayExplosion()
    {
        _SFXChannel.RaiseEvent(_fireballExplosionSFX);
    }
}
