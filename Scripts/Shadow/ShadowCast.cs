using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
public class ShadowCast : MonoBehaviour
{
    [SerializeField] private GameObject _fatherObject;
    private float _maxImageAlpha;
    private float _currentImageAlpha;
    private SpriteRenderer _spriteRenderer;
    private float _heightDistance = 4f;
    private float _initialY;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _maxImageAlpha = _spriteRenderer.color.a;
        _initialY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        AdjustAlphaBasedOnHeight();
        AdjustPosition();
    }
    void AdjustAlphaBasedOnHeight()
    {
        float distance_to_ground = _fatherObject.transform.position.y - transform.position.y;
        _currentImageAlpha = _maxImageAlpha * (1f - Mathf.Clamp01(distance_to_ground / _heightDistance));
        Color alpha = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, _currentImageAlpha);
        _spriteRenderer.color = alpha;
    }
    private void AdjustPosition()
    {
        Vector3 position = new Vector3(_fatherObject.transform.position.x, _initialY, _fatherObject.transform.position.z);
        transform.position = position;
    }
}
