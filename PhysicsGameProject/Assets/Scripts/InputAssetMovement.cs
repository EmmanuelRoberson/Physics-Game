using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputAssetMovement : MonoBehaviour, PlayerControls.IPlayerMovementActions
{
    private PlayerControls controls;
    private Vector3 moveInput;
    private Vector3 movementDirection;
    private Vector2 mousePositionDelta;

    private Transform selfTransform;

    private Rigidbody rigidbody;
    
    [SerializeField] private GameObject mouseControlledObject;
    [SerializeField] private GameObject movementControlledObject;
    
    [SerializeField] private float jumpSpeed;

    [SerializeField]
    private float movementSpeed;
    
    [SerializeField]
    private float mouseSensitivity;

    public void Awake()
    {
        selfTransform = transform;

        if (controls == null)
        {
            //controls = new PlayerControls();
            //controls.PlayerMovement.SetCallbacks(this);
        }
    }

    public void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void OnEnable()
    {
       controls.PlayerMovement.Enable();
    }

    public void OnDisable()
    {
        controls.PlayerMovement.Disable();
    }
    
    
    public void OnJump(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                break;
            case InputActionPhase.Started:
                rigidbody.velocity = Vector3.up * jumpSpeed;
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

                moveInput = Vector2.zero;
                
                break;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mousePositionDelta = context.ReadValue<Vector2>();
    }

    private void LateUpdate()
    {
        Vector3 movementVector = 
            selfTransform.forward * moveInput.y +
            selfTransform.right * moveInput.x;

        selfTransform.position += Time.deltaTime * movementSpeed * movementVector;

        var eulerAngles = mouseControlledObject.transform.eulerAngles;
        eulerAngles += new Vector3(-mousePositionDelta.y, 0, 0);
        
        mouseControlledObject.transform.eulerAngles = eulerAngles;
        movementControlledObject.transform.eulerAngles += new Vector3(0f, mousePositionDelta.x,0f);
    }
}
