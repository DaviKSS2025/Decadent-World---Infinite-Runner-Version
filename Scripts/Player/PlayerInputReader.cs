using UnityEngine;
using UnityEngine.InputSystem;

//Class only to detect player inputs and pass values.

public class PlayerInputReader : MonoBehaviour
{
    private InputSystem_Actions inputActions;

    private bool jumpPressed;
    private bool fastFallPressed;
    private bool attackPressed;
    public bool JumpPressed => jumpPressed;
    public bool FastFallPressed => fastFallPressed;

    public bool AttackPressed => attackPressed;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();

        inputActions.Player.Jump.performed += OnJumpPerformed;
        inputActions.Player.Attack.performed += OnAttackPerformed;

        inputActions.Player.FastFall.started += ctx => fastFallPressed = true;
        inputActions.Player.FastFall.canceled += ctx => fastFallPressed = false;
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        jumpPressed = true;
    }

    private void OnFastFallPerformed(InputAction.CallbackContext context)
    {
        fastFallPressed = true;
    }
    private void OnAttackPerformed(InputAction.CallbackContext context)
    {
        attackPressed = true;
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void LateUpdate()
    {
        jumpPressed = false;
        attackPressed = false;
    }

    private void OnDestroy()
    {
        inputActions.Player.Jump.performed -= OnJumpPerformed;
        inputActions.Player.FastFall.performed -= OnFastFallPerformed;
        inputActions.Player.Attack.performed -= OnAttackPerformed;
    }
}
