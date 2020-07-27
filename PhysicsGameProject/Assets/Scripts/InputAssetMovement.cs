using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputAssetMovement : MonoBehaviour, PlayerControls.IPlayerMovementActions
{
    private PlayerControls controls;
    private Vector3 moveInput;

    [SerializeField]
    private float movementSpeed;

    public void Awake()
    {
        if (controls == null)
        {
            controls = new PlayerControls();
            controls.PlayerMovement.SetCallbacks(this);
        }
    }

    public void OnEnable()
    {
       controls.PlayerMovement.Enable();
    }

    public void OnDisable()
    {
        controls.PlayerMovement.Disable();
    }

    public void Jump()
    {
        
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                break;
            case InputActionPhase.Started:
                transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y + 4,
                    transform.position.z
                );
                break;
            case InputActionPhase.Canceled:
                break;
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                moveInput = context.ReadValue<Vector2>();
                break;
            case InputActionPhase.Started:
                break;
            case InputActionPhase.Canceled:
                moveInput = context.ReadValue<Vector2>();
                break;
        }
    }

    private void Move(InputAction.CallbackContext context)
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * movementSpeed * new Vector3(moveInput.x, 0, moveInput.y) );
    }
}
