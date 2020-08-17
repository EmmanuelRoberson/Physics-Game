using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlsMovementBehaviour : MonoBehaviour, PlayerControls.IPlayerMovementActions
{
    private PlayerControls _controls;

    delegate void MovementHandler(params Vector3[] vector3s);
    
    private static MovementHandler _playerMovementDelegate;
    private static MovementHandler _playerCancelMovementDelegate;
    private static MovementHandler _playerRotateDelegate;

    public void Awake()
    {
        if (_controls == null)
        {
            _controls = new PlayerControls();
            _controls.PlayerMovement.SetCallbacks(this);
        }
    }

    public static void AddPlayerMovement(IPlayerControllable playerControllable)
    {
        _playerMovementDelegate += playerControllable.Move;
        _playerCancelMovementDelegate += playerControllable.CancelMove;
        _playerRotateDelegate += playerControllable.Rotate;
    }
    
    public void OnEnable()
    {
        _controls.PlayerMovement.Enable();
    }

    public void OnDisable()
    {
        _controls.PlayerMovement.Disable();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("PLACEHOLDER TEXT:: SPACE PRESSED(JUMP)");
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                _playerMovementDelegate.Invoke(context.ReadValue<Vector2>());
                break;
            case InputActionPhase.Canceled:
                _playerCancelMovementDelegate.Invoke(context.ReadValue<Vector2>());
                break;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _playerRotateDelegate.Invoke(context.ReadValue<Vector2>());
    }
}
