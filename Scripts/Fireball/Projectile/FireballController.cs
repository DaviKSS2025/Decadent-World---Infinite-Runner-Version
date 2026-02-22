using UnityEngine;

[RequireComponent (typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(FireballCollision))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(FireballAudioManager))]

// Central controller responsible for wiring components
// and managing the fireball state machine lifecycle.
public class FireballController : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private FireballMovement _movement;
    private FireballAnimatorController _animatorController;
    private FireballCollision _collisionDetector;
    private IFireballState _currentState;
    private bool wasVisibleOnce;
    private FireballAudioManager _audioManager;

    [SerializeField] private GameObject _coin;
    public FireballMovement Movement
    {
        get => _movement;
    }
    public FireballAnimatorController AnimatorController
    {
        get => _animatorController;
    }
    public SpriteRenderer SpriteRenderer 
    { 
        get => _spriteRenderer; 
    }
    public IFireballState CurrentState
    {
        get => _currentState;
    }
    public FireballAudioManager AudioManager
    {
        get => _audioManager;
    }

    // Movement and animation logic are plain classes to keep
    // behavior decoupled from Unity lifecycle methods.
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _movement = new FireballMovement();
        _movement.Initialize(_rigidBody);
        _animatorController = new FireballAnimatorController();
        _animatorController.Initialize(_animator);
        _collisionDetector = GetComponent<FireballCollision>();
        _collisionDetector.Initialize(this);
        _audioManager = GetComponent<FireballAudioManager>();
        wasVisibleOnce = false;
    }

    void Update()
    {
        //State updates
        _currentState.OnUpdate();
    }
    public void ChangeState(IFireballState newState)
    {
        if (_currentState != null)
        {
            _currentState.OnExit();
        }

        _currentState = newState;
        _currentState.OnEnter();
    }

    public void OnAnimationEvent(string eventName)
    {
        _currentState.HandleAnimationEvent(eventName);
    }
    private void OnEnable()
    {
        // Reinitialize state machine when reused from pool
        _currentState = new FireballTravelingState(this);
        _currentState.OnEnter();

        _coin.SetActive(true);
    }
    private void OnBecameInvisible()
    {
        // Ensures projectile is returned to pool only
        // after it has appeared on screen at least once
        if (wasVisibleOnce)
        {
            AutoDisable();
        }
    }
    private void OnBecameVisible()
    {
        wasVisibleOnce = true;
    }
    public void AutoDisable()
    {
        gameObject.SetActive(false);
    }
}
