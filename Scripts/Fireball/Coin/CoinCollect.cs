using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class CoinCollect : MonoBehaviour
{
    [SerializeField] private CoinCollectedChannel _coinChannel;
    [SerializeField] private SimpleAudioEvent _coinCollectedSFX;
    [SerializeField] private SFXChannel _SFXChannel;
    [SerializeField] private GameObject _particlesGO;
    private ParticleSystem _particlesSystemWhenCollected;
    private BoxCollider2D _collider;
    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _particlesSystemWhenCollected = _particlesGO.GetComponent<ParticleSystem>();
    }
    private void OnEnable()
    {
        _collider.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Uses event channel to decouple coin logic from score system
            _coinChannel.RaiseCoinCollected();

            _SFXChannel.RaiseEvent(_coinCollectedSFX);
            CallParticleSystem();
            DisableItself();
        }
    }
    private void DisableItself()
    {
        _collider.enabled = false;

        // Disables instead of Destroy to support object pooling
        gameObject.SetActive(false);
    }
    private void CallParticleSystem()
    {
        _particlesGO.transform.position = transform.position;
        _particlesSystemWhenCollected.Play();
    }
}
