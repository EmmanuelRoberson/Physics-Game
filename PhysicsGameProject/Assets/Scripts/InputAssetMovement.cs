using UnityEngine;
using UnityEngine.InputSystem;

public class InputAssetMovement : MonoBehaviour, PlayerControls.IPlayerMovementActions
{
    private PlayerControls controls;
    private Vector3 moveInput;
    private Vector2 mousePositionDelta;

    [SerializeField] private GameObject mouseControlledObject;
    [SerializeField] private GameObject movementControlledObject;

    [SerializeField]
    private float movementSpeed;
    
    [SerializeField]
    private float mouseSensitivity;

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

    public void OnLook(InputAction.CallbackContext context)
    {
        mousePositionDelta = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementVector = CustomMath.DirectionalizeVector(transform.forward, moveInput).normalized;
        transform.Translate(Time.deltaTime * movementSpeed * movementVector);
        mouseControlledObject.transform.eulerAngles += new Vector3(-mousePositionDelta.y, mousePositionDelta.x, 0);
        movementControlledObject.transform.eulerAngles += new Vector3(0f,mousePositionDelta.x,0f);
    }
}
