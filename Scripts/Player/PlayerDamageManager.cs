using UnityEngine;

public class PlayerDamageManager : MonoBehaviour
{
    private PlayerController _controller;
    [SerializeField] private DamageChannel _damageChannel;
    public void Initialize(PlayerController controller)
    {
        _controller = controller;
    }
    private void OnEnable()
    {
        _damageChannel.PlayerDamaged += OnPlayerDamaged;
    }
    private void OnDisable()
    {
        _damageChannel.PlayerDamaged -= OnPlayerDamaged;
    }
    private void OnPlayerDamaged()
    {
        _controller.ChangeState(new PlayerDeadState(_controller));
        this.enabled = false;
    }

}
