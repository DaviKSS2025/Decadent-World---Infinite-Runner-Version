using System;
using UnityEngine;

//Mandatory components to work
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInputReader))]
[RequireComponent(typeof(PlayerGroundChecker))]
[RequireComponent(typeof(PlayerAudioManager))]

// Central player coordinator.
// Wires subsystems together and manages player state machine lifecycle.
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private IPlayerState _currentState;
    private Animator _animator;
    private PlayerInputReader _inputReader;
    private PlayerAnimatorController _animatorController;
    private PlayerMovement _movement;
    private PlayerGroundChecker _groundChecker;
    private PlayerDamageManager _damageManager;
    private bool isGrounded = true;
    private PlayerAudioManager _audioManager;

    [SerializeField] private GameObject _attackHitbox;
    public Rigidbody2D RigidBody
    {
        get => _rigidBody;
    }
    public bool IsGrounded
    {
        get => isGrounded;
        set => isGrounded = value;
    }
    public PlayerInputReader PlayerInputReader
    {
        get => _inputReader;
    }
    public PlayerAnimatorController PlayerAnimatorController
    {
        get => _animatorController;
    }
    public PlayerMovement PlayerMovement
    {
        get => _movement;
    }
    public GameObject AttackHitbox
    {
        get => _attackHitbox;
    }
    public PlayerAudioManager AudioManager
    {
        get => _audioManager;
    }

    // Core gameplay logic implemented in plain C# classes
    // to reduce dependency on Unity lifecycle.
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _inputReader = GetComponent<PlayerInputReader>();
        _groundChecker = GetComponent<PlayerGroundChecker>();
        _groundChecker.Initialize(this);
        _audioManager = GetComponent<PlayerAudioManager>();
        _movement = new PlayerMovement();
        _movement.Initialize(_rigidBody);

        _animatorController = new PlayerAnimatorController(_animator);


        _damageManager = GetComponent<PlayerDamageManager>();
        _damageManager.Initialize(this);


        // Initial state when player is enabled
        _currentState = new PlayerGroundedState(this);
        _currentState.OnEnter();
    }


    void Update()
    {
        //State updates
        _currentState.OnUpdate();
    }

    public void ChangeState(IPlayerState newState)
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
}
