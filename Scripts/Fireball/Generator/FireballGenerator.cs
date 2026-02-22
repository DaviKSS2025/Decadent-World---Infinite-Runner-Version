using UnityEngine;

// Simple fixed-size object pool to avoid runtime Instantiate/Destroy
// Pool size intentionally small (4) due to controlled spawn pacing
public class FireballGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _fireballProjectilesPool;
    [SerializeField] private DamageChannel _damageChannel;
    private float _maxTimeToLaunchProjectile = 3f;
    private float _minTimeToLaunchProjectile = 1f;
    private float _currentTimeToLaunchProjectile;

    private void OnEnable()
    {
        _damageChannel.PlayerDamaged += OnPlayerDamaged;
    }
    private void OnDisable()
    {
        _damageChannel.PlayerDamaged -= OnPlayerDamaged;
    }
    void Update()
    {
        ManageTimeToLaunchProjectile();
    }

    private void ManageTimeToLaunchProjectile()
    {
        if (_currentTimeToLaunchProjectile > 0)
        {
            DecreaseTimeToLaunchProjectile();
        }
        else
        {
            _currentTimeToLaunchProjectile = CalculateNextTimeToLaunchProjectile();
            LaunchProjectile();
        }
    }

    private void DecreaseTimeToLaunchProjectile()
    {
        _currentTimeToLaunchProjectile -= Time.deltaTime;
    }
    private float CalculateNextTimeToLaunchProjectile()
    {
        // Random interval prevents predictable obstacle patterns
        return Random.Range(_minTimeToLaunchProjectile, _maxTimeToLaunchProjectile);
    }
    private void LaunchProjectile()
    {
        foreach (GameObject projectile in _fireballProjectilesPool)
        {
            if (!projectile.activeInHierarchy)
            {
                projectile.SetActive(true);
                ResetProjectilePosition(projectile);
                break;
            }
        }
    }
    private void ResetProjectilePosition(GameObject projectile)
    {
        projectile.transform.position = transform.position;
    }

    private void OnPlayerDamaged()
    {
        // Stops spawning when gameplay loop ends
        gameObject.SetActive(false);
    }

}
