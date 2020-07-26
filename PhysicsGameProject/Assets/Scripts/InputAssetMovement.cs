using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputAssetMovement : MonoBehaviour, PlayerControls.IPlayerMovementActions
{
    private PlayerControls controls;

    public void OnEnable()
    {
        if (controls == null)
        {
            controls = new PlayerControls();
            controls.PlayerMovement.SetCallbacks(this);
        }
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
                Debug.Log("Submit Performed");
                break;
            case InputActionPhase.Started:
                Debug.Log("Submit Started");
                transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y + 4,
                    transform.position.z
                );
                break;
            case InputActionPhase.Canceled:
                Debug.Log("Submit Canceled");
                break;
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
