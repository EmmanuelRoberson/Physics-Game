using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallPlayerMovementBehaviour : MonoBehaviour, PlayerControls.IPlayerMovementActions
{
    [SerializeReference] private Transform _headTransform;
    private Vector3 _headOffset;

    public float moveSpeed;
    private float _moveSpeedMagnitude = 10; //set magnitude so any changes made to moveSpeed are done x10
    
    private Transform _selfTransform;
    private Rigidbody _selfRigidbody;
    
    private PlayerControls _controls;
    private Vector3 _moveVector; // direction the ball will roll relative to self space
    private Vector3 _lookVector; // direction the ball will face relative to the world space

    public void Awake()
    {
        _selfTransform = transform;
        _selfRigidbody = GetComponent<Rigidbody>();

        _headOffset = _headTransform.position - _selfTransform.position;
        
        if (_controls == null)
        { 
            _controls = new PlayerControls();
            _controls.PlayerMovement.SetCallbacks(this);
        }
    }

    public void LateUpdate()
    {
        Vector3 rollVector =
            (_selfTransform.forward * -_moveVector.x +
             _selfTransform.right * _moveVector.y);

        //_selfTransform.position += Time.deltaTime * rollVector;
        _selfRigidbody.angularVelocity = (moveSpeed * _moveSpeedMagnitude * Time.fixedDeltaTime * rollVector);
        
        _headTransform.position = _selfTransform.position + _headOffset;
        
        Vector3 newEulerAngles = _headTransform.eulerAngles;
        newEulerAngles += new Vector3(-_lookVector.y, _lookVector.x, 0);
        
        _headTransform.eulerAngles = newEulerAngles;
        _selfTransform.localEulerAngles += new Vector3(0, _lookVector.x,0);
    }

    // INPUT ASSET OVERRIDE FUNCTIONS
    public void OnJump(InputAction.CallbackContext context)
    {
        _selfRigidbody.AddForce(0,10,0);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                _moveVector = context.ReadValue<Vector2>();
                break;
            case InputActionPhase.Started:
                break;
            case InputActionPhase.Canceled:
                _moveVector = Vector2.zero;
                break;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _lookVector = context.ReadValue<Vector2>();
    }
    
    //
}
