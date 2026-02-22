using UnityEngine;

public class DeathCanvasObserver : MonoBehaviour
{
    [SerializeField] private DamageChannel _damageChannel;
    [SerializeField] private GameObject _deathCanvasParent;
    [SerializeField] private SFXChannel _SFXChannel;
    [SerializeField] private SimpleAudioEvent _doomSFX;

    private void Awake()
    {
        _damageChannel.PlayerDamaged += OnPlayerDamaged;
    }
    private void OnDisable()
    {
        _damageChannel.PlayerDamaged -= OnPlayerDamaged;
    }
    private void OnPlayerDamaged()
    {
        _deathCanvasParent.SetActive(true);
        _SFXChannel.RaiseEvent(_doomSFX);
    }

}
