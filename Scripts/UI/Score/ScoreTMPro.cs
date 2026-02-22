using TMPro;
using UnityEngine;
[RequireComponent(typeof(TextMeshProUGUI))]
[RequireComponent (typeof(Animator))]
public class ScoreTMPro : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private int _score = 0;
    private Animator _animator;
    private ScoreAnimator _scoreAnimator;
    [SerializeField] CoinCollectedChannel _coinChannel;
    [SerializeField] DamageChannel _damageChannel;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _animator = GetComponent<Animator>();
        _scoreAnimator = new ScoreAnimator();
        _scoreAnimator.Initialize(_animator);
    }
    private void OnEnable()
    {
        _coinChannel.CoinCollected += OnCoinCollected;
        _damageChannel.PlayerDamaged += OnPlayerDamaged;
    }
    private void OnDisable()
    {
        _coinChannel.CoinCollected -= OnCoinCollected;
        _damageChannel.PlayerDamaged -= OnPlayerDamaged;
    }
    private void OnCoinCollected()
    {
        _scoreAnimator.PlayingScore();
        _score++;
        _text.text = $"Score: {_score}";
    }
    private void OnPlayerDamaged()
    {
        SaveController.Instance.SetMaxScore(_score);
    }
}
